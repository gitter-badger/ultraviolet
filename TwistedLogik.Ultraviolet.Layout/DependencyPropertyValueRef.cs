﻿using System;
using TwistedLogik.Nucleus;

namespace TwistedLogik.Ultraviolet.Layout
{
    /// <summary>
    /// Represents a wrapper around reference types which are stored in dependency properties.
    /// </summary>
    internal class DependencyPropertyValueRef<T> : IDependencyPropertyValue where T : class 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyPropertyValueRef{T}"/> class.
        /// </summary>
        /// <param name="owner">The dependency object that owns the property value.</param>
        /// <param name="property">The dependency property which has its value represented by this object.</param>
        public DependencyPropertyValueRef(DependencyObject owner, DependencyProperty property)
        {
            Contract.Require(owner, "owner");
            Contract.Require(property, "property");

            this.owner    = owner;
            this.property = property;
        }

        /// <inheritdoc/>
        public void Digest()
        {
            var currentValue = GetValue();
            if (currentValue != previousValue)
            {
                // TODO: Invoke callback
                previousValue = currentValue;
            }
        }

        /// <inheritdoc/>
        public void ClearLocalValue()
        {
            hasLocalValue = false;
        }

        /// <inheritdoc/>
        public DependencyObject Owner
        {
            get { return owner; }
        }

        /// <inheritdoc/>
        public DependencyProperty Property
        {
            get { return property; }
        }

        /// <summary>
        /// Gets the dependency property's calculated value.
        /// </summary>
        /// <returns>The dependency property's calculated value.</returns>
        public T GetValue()
        {
            if (hasLocalValue)
            {
                return localValue;
            }
            if (property.Metadata.IsInherited && owner.DependencyContainer != null)
            {
                return owner.DependencyContainer.GetValueRef<T>(property);
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets or sets the dependency property's local value.
        /// </summary>
        public T LocalValue
        {
            get { return localValue; }
            set 
            { 
                localValue = value;
                hasLocalValue = true;
            }
        }

        /// <summary>
        /// Gets or sets the dependency property's default value.
        /// </summary>
        public T DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }

        /// <summary>
        /// Gets the dependency property's previous value as of the last call to <see cref="Digest()"/>.
        /// </summary>
        public T PreviousValue
        {
            get { return previousValue; }
        }

        // Property values.
        private readonly DependencyObject owner;
        private readonly DependencyProperty property;
        private Boolean hasLocalValue;
        private T localValue;
        private T defaultValue;
        private T previousValue;
    }
}
