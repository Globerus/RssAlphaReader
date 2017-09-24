using RssAlphaReader.Configuration;
using RssAlphaReader.Configuration.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RssAlphaReader.Controller
{
    public abstract class BaseController
    {
        protected readonly IConstants config;

        public BaseController(IConstants config)
        {
            this.config = config;
        }

        public T ProcessChildrenElements<T>(XElement element, T model) where T : class
        {
            foreach (var child in element.Elements())
            {
                if (child.Name.NamespaceName == child.GetDefaultNamespace())
                {
                    model = ProcessElement(child, model);
                }
                else
                {
                    model = ProcessExtension(child, model);
                }
            }

            return model;
        }

        public T ProcessElement<T>(XElement element, T model) where T : class
        {
            Type type;

            if(!config.ElementToType.TryGetValue(element.Name.LocalName, out type))
            {
                return model;
            }

            var elementObject = (type == typeof(string)) ? string.Empty : Activator.CreateInstance(type);

            if (!element.HasElements)
            {
                if (element.HasAttributes)
                {
                    elementObject = ProcessAttributes(element, elementObject);
                }

                if (!element.IsEmpty)
                {
                    elementObject = SetPropertyValue(config.ElementValueToProperty, element.Name.LocalName, element.Value, elementObject);
                }

                model = SetPropertyValue(config.ElementToProperty, element.Name.LocalName, elementObject, model);
            }
            else
            {
                elementObject = ProcessChildrenElements(element, elementObject);

                model = SetPropertyValue(config.ElementToProperty, element.Name.LocalName, elementObject, model);
            }

            return model;
        }

        public T ProcessAttributes<T>(XElement element, T model) where T : class
        {
            foreach (var attr in element.Attributes())
            {
                Type type;

                if (!config.AttributeToType.TryGetValue(attr.Name.LocalName, out type))
                {
                    continue;
                }

                var newObject = (type == typeof(string)) ? string.Empty : Activator.CreateInstance(type);

                newObject = SetPropertyValue(config.AttributeValueToProperty, attr.Name.LocalName, attr.Value, newObject);
                model = SetPropertyValue(config.AttributeToProperty, attr.Name.LocalName, newObject, model);
            }

            return model;
        }

        public T ProcessExtension<T>(XElement element, T model)
        {
            var property = model.GetType()
                                .GetProperty("Extensions");

            if (property == null)
            {
                return model;
            }

            var extensionCollection = property.GetValue(model);

            extensionCollection = (extensionCollection == null) ? Activator.CreateInstance(property.PropertyType) : extensionCollection;

            var extension = ((IEnumerable)extensionCollection).Cast<dynamic>()
                                                              .Where(e => e.Namespace == element.Name.NamespaceName)
                                                              .FirstOrDefault();

            if (extension == null)
            {
                Type extensionType = property.PropertyType.GetGenericArguments()[0];
                extension = Activator.CreateInstance(extensionType);

                extension.Namespace = element.Name.NamespaceName;
                extension.Name = element.GetPrefixOfNamespace(extension.Namespace);

                extensionCollection.GetType()
                                   .GetMethod("Add")
                                   .Invoke(extensionCollection, new[] { extension });

                property.SetValue(model, extensionCollection);
            }

            Type formatter;

            if (GlobalConstants.SupportedFormatters.TryGetValue(extension.Name, out formatter))
            {
                var formatterObject = Activator.CreateInstance(formatter);

                var bootstrapper = GlobalConstants.BootstrapMethods
                                                  .Where(e => e.Key == extension.Name)
                                                  .Select(e => e.Value)
                                                  .FirstOrDefault();

                formatter.GetMethod(bootstrapper)
                         .Invoke(formatterObject, new object[] { extension, element });
            }

            extension.Description = element.ToString();

            return model;
        }

        public T ProcessExtensionElement<T>(XElement element, T model) where T : class
        {
            Type type;

            var typeAvailable = config.ElementToType.TryGetValue(element.Name.LocalName, out type);

            var newObject = (!typeAvailable) ? model : (type == typeof(string)) ? string.Empty
                                                                                : Activator.CreateInstance(type);

            if (!element.HasElements)
            {
                if (element.HasAttributes)
                {
                    newObject = ProcessAttributes(element, newObject);
                }

                if (!element.IsEmpty)
                {
                    newObject = SetPropertyValue(config.ElementValueToProperty, element.Name.LocalName, element.Value, newObject);
                }

                model = SetPropertyValue(config.ElementToProperty, element.Name.LocalName, newObject, model);
            }
            else
            {
                foreach (var subElement in element.Elements())
                {
                    newObject = ProcessExtensionElement(subElement, newObject);
                }

                model = (!typeAvailable) ? model : SetPropertyValue(config.ElementToProperty, element.Name.LocalName, newObject, model);
            }

            return model;
        }

        public T SetPropertyValue<T>(IDictionary<string, string> collection, string name, object value, T model) where T : class
        {
            string propertyName;

            if (!collection.TryGetValue(name, out propertyName) && value.GetType() == typeof(string))
            {
                return value as T;
            }

            var property = model.GetType()
                                .GetProperty(propertyName);

            if (property.PropertyType.IsGenericType)
            {
                var propertyValue = property.GetValue(model);

                propertyValue = (propertyValue == null) ? Activator.CreateInstance(property.PropertyType) : propertyValue;

                propertyValue.GetType()
                             .GetMethod("Add")
                             .Invoke(propertyValue, new[] { value });

                property.SetValue(model, propertyValue);
            }
            else
            {
                property.SetValue(model, value);
            }

            return model;
        }
    }
}
