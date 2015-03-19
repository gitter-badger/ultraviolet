﻿using System;
using TwistedLogik.Ultraviolet.UI.Presentation.Input;

namespace TwistedLogik.Ultraviolet.UI.Presentation
{
    /// <summary>
    /// Represents an element capable of basic input handling.
    /// </summary>
    public interface IInputElement
    {
        /// <summary>
        /// Adds a handler for a routed event to the element.
        /// </summary>
        /// <param name="evt">A <see cref="RoutedEvent"/> that identifies the routed event for which to add a handler.</param>
        /// <param name="handler">A delegate that represents the handler to add to the element for the specified routed event.</param>
        void AddHandler(RoutedEvent evt, Delegate handler);

        /// <summary>
        /// Removes a handler for a routed event from the element.
        /// </summary>
        /// <param name="evt">A <see cref="RoutedEvent"/> that identifies the routed event for which to remove a handler.</param>
        /// <param name="handler">A delegate that represents the handler to remove from the element for the specified routed event.</param>
        void RemoveHandler(RoutedEvent evt, Delegate handler);

        /// <summary>
        /// Gets or sets a value that indicates whether this element can receive focus.
        /// </summary>
        Boolean Focusable { get; set; }

        /// <summary>
        /// Gets a value indicating whether this element is enabled.
        /// </summary>
        Boolean IsEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether this element has keyboard focus.
        /// </summary>
        Boolean IsKeyboardFocused { get; }

        /// <summary>
        /// Gets a value indicating whether this element or any of its descendants have keyboard focus.
        /// </summary>
        Boolean IsKeyboardFocusWithin { get; }

        /// <summary>
        /// Gets a value indicating whether this element has captured the mouse.
        /// </summary>
        Boolean IsMouseCaptured { get; }

        /// <summary>
        /// Gets a value indicating whether the cursor is located over this element or any of its descendants.
        /// </summary>
        Boolean IsMouseOver { get; }

        /// <summary>
        /// Gets a value indicating whether this element is the topmost element which is directly under the mouse cursor.
        /// </summary>
        Boolean IsMouseDirectlyOver { get; }

        /// <summary>
        /// Occurs when the element gains keyboard focus.
        /// </summary>
        event UIElementRoutedEventHandler GotKeyboardFocus;

        /// <summary>
        /// Occurs when the element loses keyboard focus.
        /// </summary>
        event UIElementRoutedEventHandler LostKeyboardFocus;

        /// <summary>
        /// Occurs when the element receives text input from the keyboard.
        /// </summary>
        event UIElementKeyboardEventHandler PreviewTextInput;

        /// <summary>
        /// Occurs when a key is pressed while the element has focus.
        /// </summary>
        event UIElementKeyDownEventHandler PreviewKeyDown;

        /// <summary>
        /// Occurs when a key is released while the element has focus.
        /// </summary>
        event UIElementKeyEventHandler PreviewKeyUp;

        /// <summary>
        /// Occurs when the element receives text input from the keyboard.
        /// </summary>
        event UIElementKeyboardEventHandler TextInput;

        /// <summary>
        /// Occurs when a key is pressed while the element has focus.
        /// </summary>
        event UIElementKeyDownEventHandler KeyDown;

        /// <summary>
        /// Occurs when a key is released while the element has focus.
        /// </summary>
        event UIElementKeyEventHandler KeyUp;

        /// <summary>
        /// Occurs when the element gains mouse capture.
        /// </summary>
        event UIElementMouseEventHandler GotMouseCapture;

        /// <summary>
        /// Occurs when the element loses mouse capture.
        /// </summary>
        event UIElementRoutedEventHandler LostMouseCapture;

        /// <summary>
        /// Occurs when the mouse cursor moves over the element.
        /// </summary>
        event UIElementMouseMoveEventHandler PreviewMouseMoveEvent;

        /// <summary>
        /// Occurs when a mouse button is pressed while the cursor is over the element.
        /// </summary>
        event UIElementMouseButtonEventHandler PreviewMouseDownEvent;

        /// <summary>
        /// Occurs when a mouse button is released while the cursor is over the element.
        /// </summary>
        event UIElementMouseButtonEventHandler PreviewMouseUpEvent;

        /// <summary>
        /// Occurs when a mouse button is clicked while the cursor is over the element.
        /// </summary>
        event UIElementMouseButtonEventHandler PreviewMouseClickEvent;

        /// <summary>
        /// Occurs when a mouse button is double clicked while the cursor is over the element.
        /// </summary>
        event UIElementMouseButtonEventHandler PreviewMouseDoubleClickEvent;

        /// <summary>
        /// Occurs when the mouse wheel is scrolled while the cursor is over the element.
        /// </summary>
        event UIElementMouseWheelEventHandler PreviewMouseWheelEvent;

        /// <summary>
        /// Occurs when the mouse cursor moves over the element.
        /// </summary>
        event UIElementMouseMoveEventHandler MouseMoveEvent;

        /// <summary>
        /// Occurs when a mouse button is pressed while the cursor is over the element.
        /// </summary>
        event UIElementMouseButtonEventHandler MouseDownEvent;

        /// <summary>
        /// Occurs when a mouse button is released while the cursor is over the element.
        /// </summary>
        event UIElementMouseButtonEventHandler MouseUpEvent;

        /// <summary>
        /// Occurs when a mouse button is clicked while the cursor is over the element.
        /// </summary>
        event UIElementMouseButtonEventHandler MouseClickEvent;

        /// <summary>
        /// Occurs when a mouse button is double clicked while the cursor is over the element.
        /// </summary>
        event UIElementMouseButtonEventHandler MouseDoubleClickEvent;

        /// <summary>
        /// Occurs when the mouse wheel is scrolled while the cursor is over the element.
        /// </summary>
        event UIElementMouseWheelEventHandler MouseWheelEvent;
    }
}
