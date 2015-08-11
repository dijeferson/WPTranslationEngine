# Windows Phone 8.1 Simple Translation Engine
A simple UI translation engine for Windows Phone 8.1 Store Apps that complies with the DRY (_Don't Repeat Yourself_) principle.

When using the regular resource manager to translate the app sometimes you need more than one constant for the same thing. Example: The case when you have a translation that needs to be reflected in a button and a textblock. In this case you will need a constant XXXXX.Content and XXXXXX.Text, both with the same translation.

With this simple engine all you need to do is:
1. Create the translation constant in the resource file as a simple constant (neither .Text nor .Content needed).
2. In your control, fill the __Tag__ attribute with the translation constant.
3. In the constructor of your view insert the call to the ```TranslationEngine.Translate(this)```
4. That's it.
