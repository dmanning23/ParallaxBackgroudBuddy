# ParallaxBackgroudBuddy
MonoGame library for drawing background images at different scrolling layers

To use:

```
//Create the object
Background = new ParallaxBackground();

//Add all the layers
Background.AddLayer(new Filename(@"Backgrounds\Forest1\Background"), .1f, Content);
Background.AddLayer(new Filename(@"Backgrounds\Forest1\Layer3"), .3f, Content);
Background.AddLayer(new Filename(@"Backgrounds\Forest1\Layer2"), .6f, Content);
Background.AddLayer(new Filename(@"Backgrounds\Forest1\Layer1"), 1f, Content);
Background.AddLayer(new Filename(@"Backgrounds\Forest1\Foreground"), 1.5f, Content);

//Make sure the layers are sorted!
Background.Sort();

...

//Draw the background
Background.Draw(spriteBatch, Resolution.ScreenArea, new Vector2(MovementOffset, 0f));
```
