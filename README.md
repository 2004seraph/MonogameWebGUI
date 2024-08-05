# Cross Platform UI in Monogame

An example project using [Puppeteer Sharp](https://github.com/hardkoded/puppeteer-sharp) to achieve cross platform UI in [Monogame](https://github.com/MonoGame/MonoGame). This allows websites to render on top of the game, so you could in theory make your game's UI in HTML/CSS/JS or whichever framework you use (really anything that works on the web). This is what we are currently trying to achieve in Contraband Software's planned Rock Engine.

Currently it can render everything correctly, but many features are still missing (listed below).

![Girl with purple hair](preview.png?raw=true "Preview Image")

Originally I planned to use cefSharp, but the project is pretty much Windows-only, making it useless for cross platform development.

## Missing Features
- it currently is loading a file from a server, we need it to load locally, this is non-trivial due to security policies of chromium
- no events are piped to the web-side of things
- it is not continuously rendering (too slow)
- it currently dynamically downloads chromium based on the platform, we need to bundle a chromium
- It needs to be wrapped in a packaging class for integration with
