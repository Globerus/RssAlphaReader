using RssSyndicationFeed.Configuration;
using RssSyndicationFeed.Configuration.Interface;
using RssSyndicationFeed.Model.Interface;
using RssSyndicationFeed.Model.SubContent;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RssSyndicationFeed.Controller
{
    public abstract class BaseController
    {
        protected readonly IConstants config;

        public BaseController(IConstants config)
        {
            this.config = config;
        }

        public T DynamicElementLoad<T>(XElement element, T model) where T : class
        {
            if (element.Name.NamespaceName != element.GetDefaultNamespace())
            {
                model = DynamicExtensionLoad(element, model);
                return model;
            }

            Type type;

            if (!config.ElementToType.TryGetValue(element.Name.LocalName, out type))
            {
                return model;
            }

            var newObject = (type == typeof(string)) ? string.Empty : Activator.CreateInstance(type);

            if (!element.HasElements)
            {
                if (element.HasAttributes)
                {
                    newObject = DynamicAttributeLoad(element, newObject);
                }

                if (!element.IsEmpty)
                {
                    newObject = SetPropertyValue(config.ElementValueToProperty, element.Name.LocalName, element.Value, newObject);
                }

                model = SetPropertyValue(config.ElementToProperty, element.Name.LocalName, newObject, model);

                return model;
            }

            foreach (var subElement in element.Elements())
            {
                newObject = DynamicElementLoad(subElement, newObject);
            }

            model = SetPropertyValue(config.ElementToProperty, element.Name.LocalName, newObject, model);

            return model;

        }

        public T DynamicAttributeLoad<T>(XElement element, T model) where T : class
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

        public T DynamicExtensionLoad<T>(XElement element, T model)
        {
            var property = model.GetType()
                                .GetProperty("Extensions");

            if(property == null)
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
                extension = Activator.CreateInstance(GlobalConstants.DependencyObjects["extension"]);

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

        public T DynamicExtensionElementLoad<T>(XElement element, T model) where T : class
        {
            Type type;

            var typeAvailable = config.ElementToType.TryGetValue(element.Name.LocalName, out type);

            var newObject = (!typeAvailable) ? model : (type == typeof(string)) ? string.Empty
                                                                                : Activator.CreateInstance(type);

            if (!element.HasElements)
            {
                if (element.HasAttributes)
                {
                    newObject = DynamicAttributeLoad(element, newObject);
                }

                if (!element.IsEmpty)
                {
                    newObject = SetPropertyValue(config.ElementValueToProperty, element.Name.LocalName, element.Value, newObject);
                }

                model = SetPropertyValue(config.ElementToProperty, element.Name.LocalName, newObject, model);

                return model;
            }

            foreach (var subElement in element.Elements())
            {
                newObject = DynamicExtensionElementLoad(subElement, newObject);
            }

            model = (!typeAvailable) ? model : SetPropertyValue(config.ElementToProperty, element.Name.LocalName, newObject, model);

            return model;
        }

        public T StartLoading<T>(XElement root, T model) where T : class
        {
            foreach (var element in root.Elements())
            {
                if (element.Name.NamespaceName == element.GetDefaultNamespace())
                {
                    model = DynamicElementLoad(element, model);
                }
                else
                {
                    model = DynamicExtensionLoad(element, model);
                }
            }

            return model;
        }
    }
}
