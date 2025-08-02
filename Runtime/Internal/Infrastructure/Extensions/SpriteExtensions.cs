using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Infrastructure.Extensions
{
    internal static class SpriteExtensions
    {
        private static readonly Vector2 Pivot = new(0.5f, 0.5f);
        
        public static Sprite CreateSpriteFromBytes(this byte[] data)
        {
            var texture = new Texture2D(2, 2);
            texture.LoadImage(data, true);
            texture.wrapMode = TextureWrapMode.Clamp;
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Pivot);    
        }
        
        public static void Dispose(this Sprite sprite)
        {
            if (sprite == null || sprite.GetInstanceID() > 0)
            {
                return;
            }
            
            Object.Destroy(sprite.texture);
            Object.Destroy(sprite);
        }
    }
}