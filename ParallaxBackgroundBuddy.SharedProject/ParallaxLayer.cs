using FilenameBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RenderBuddy;
using System;

namespace ParallaxBackgroundBuddy
{
	/// <summary>
	/// A single layer of a parallax background
	/// </summary>
	public class ParallaxLayer
	{
		#region Properties

		/// <summary>
		/// The texture that is drawn at this layer of the parallax background
		/// </summary>
		public Texture2D LayerTexture { get; set; }

		/// <summary>
		/// How fast to scale the movement for this layer
		/// </summary>
		public float MovementDelta { get; set; }

		#endregion //Properties

		#region Methods

		public ParallaxLayer(Filename textureFilename, float movementDelta, IRenderer renderer)
		{
			var textureInfo = renderer.LoadImage(textureFilename, null, null);
			LayerTexture = textureInfo.Texture;
			//LayerTexture = content.Load<Texture2D>(textureFilename.GetRelPathFileNoExt());
			MovementDelta = movementDelta;
		}

		public void Draw(SpriteBatch spriteBatch, Rectangle destination, Vector2 movementPosition)
		{
			if (movementPosition.X >= 0f)
			{
				DrawPositive(spriteBatch, destination, movementPosition);
			}
			else
			{
				DrawNegative(spriteBatch, destination, movementPosition);
			}
		}

		private void DrawPositive(SpriteBatch spriteBatch, Rectangle destination, Vector2 movementPosition)
		{
			var movementOffset = movementPosition.X * MovementDelta;
			while (movementOffset >= destination.Width)
			{
				movementOffset -= destination.Width;
			}

			while (movementOffset <= (-1 * destination.Width))
			{
				movementOffset += destination.Width;
			}

			//get the x-offset due to the movement
			var firstWidthDelta = Math.Abs((destination.Width - movementOffset)) / destination.Width;
			var secondWidthDelta = 1f - firstWidthDelta;

			var destinationOffset = destination.X + (int)(destination.Width * firstWidthDelta);

			var sourceEndOffset = (int)(LayerTexture.Width * firstWidthDelta);
			var soureBeginOffset = LayerTexture.Width - sourceEndOffset;

			var firstDestinationRect = new Rectangle(destination.X, destination.Y, (int)(destination.Width * firstWidthDelta), destination.Height);
			var firstSourceRect = new Rectangle(soureBeginOffset, 0, sourceEndOffset, LayerTexture.Height);

			var secondDestinationRect = new Rectangle(destinationOffset, destination.Y, (int)(destination.Width * secondWidthDelta), destination.Height);
			var secondSourceRect = new Rectangle(0, 0, (int)(LayerTexture.Width * secondWidthDelta), LayerTexture.Height);

			//draw the first rectangle
			spriteBatch.Draw(LayerTexture, firstDestinationRect, firstSourceRect, Color.White);

			//the second rectangle to draw
			spriteBatch.Draw(LayerTexture, secondDestinationRect, secondSourceRect, Color.White);
		}

		private void DrawNegative(SpriteBatch spriteBatch, Rectangle destination, Vector2 movementPosition)
		{
			var movementOffset = movementPosition.X * MovementDelta;

			while (movementOffset <= (-1 * destination.Width))
			{
				movementOffset += destination.Width;
			}

			//get the x-offset due to the movement
			var firstWidthDelta = (destination.Width + movementOffset) / destination.Width;
			var secondWidthDelta = 1f - firstWidthDelta;

			var destinationOffset = destination.X + (int)(destination.Width * secondWidthDelta);

			var sourceEndOffset = (int)(LayerTexture.Width * firstWidthDelta);
			var soureBeginOffset = LayerTexture.Width - sourceEndOffset;

			var firstDestinationRect = new Rectangle(destination.X, destination.Y, (int)(destination.Width * secondWidthDelta), destination.Height);
			var firstSourceRect = new Rectangle(sourceEndOffset, 0, (int)(LayerTexture.Width * secondWidthDelta), LayerTexture.Height);

			var secondDestinationRect = new Rectangle(destinationOffset, destination.Y, (int)(destination.Width * firstWidthDelta), destination.Height);
			var secondSourceRect = new Rectangle(0, 0, sourceEndOffset, LayerTexture.Height);

			//draw the first rectangle
			spriteBatch.Draw(LayerTexture, firstDestinationRect, firstSourceRect, Color.White);

			//the second rectangle to draw
			spriteBatch.Draw(LayerTexture, secondDestinationRect, secondSourceRect, Color.White);
		}

		#endregion //Methods
	}
}
