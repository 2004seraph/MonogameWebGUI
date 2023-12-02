using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PuppeteerSharp;

namespace cefsharptesting;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    Texture2D sewerTexture;
    Texture2D guiTexture;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    private async Task<Stream> Browser()
    {
        using var browserFetcher = new BrowserFetcher();

        Console.WriteLine("Downloading chromium");
        await browserFetcher.DownloadAsync();
        var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true,
            DefaultViewport = new ViewPortOptions{ 
                Width = _graphics.PreferredBackBufferWidth,
                Height = _graphics.PreferredBackBufferHeight
            }
        });
        
        var page = await browser.NewPageAsync();
        
        await page.GoToAsync("https://guitest.samtaseff.repl.co/"); // https://transharmreduction.org/
        
        ScreenshotOptions sso = new ScreenshotOptions
        {
            OmitBackground = true,
            Type = ScreenshotType.Png
        };
        return await page.ScreenshotStreamAsync(sso);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        
        Stream image = Browser().Result;

        guiTexture = Texture2D.FromStream(GraphicsDevice, image);
        sewerTexture = Content.Load<Texture2D>("Sewer");

        // Texture2D imageTexture = new(GraphicsDevice, 400, 400);
        // imageTexture.SetData<byte>(image);
        
        Console.WriteLine(image.Length);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        _graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(
            sewerTexture, 
            new Rectangle(0, 0, _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferHeight), 
            Color.White);
        
        _spriteBatch.Draw(
            guiTexture, 
            new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), 
            Color.White);
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
