using System;
using System.Runtime.InteropServices;

namespace engn
{
    public class Entity
    {
        private readonly IntPtr _entity;

        [DllImport(@"./engine")] private static extern IntPtr CreateEntity();
        [DllImport(@"./engine")] private static extern ushort GetWidthEntity(IntPtr entity);
        [DllImport(@"./engine")] private static extern ushort GetHeightEntity(IntPtr entity);
        [DllImport(@"./engine")] private static extern void SetWidthEntity(IntPtr entity, ushort w);
        [DllImport(@"./engine")] private static extern void SetHeightEntity(IntPtr entity, ushort w);
        [DllImport(@"./engine")] private static extern short GetXEntity(IntPtr entity);
        [DllImport(@"./engine")] private static extern short GetYEntity(IntPtr entity);
        [DllImport(@"./engine")] private static extern void SetXEntity(IntPtr entity, short x);
        [DllImport(@"./engine")] private static extern void SetYEntity(IntPtr entity, short y);
        [DllImport(@"./engine")] private static extern ushort GetTileWEntity(IntPtr entity);
        [DllImport(@"./engine")] private static extern ushort GetTileHEntity(IntPtr entity);
        [DllImport(@"./engine")] private static extern void SetTileWEntity(IntPtr entity, ushort w);
        [DllImport(@"./engine")] private static extern void SetTileHEntity(IntPtr entity, ushort h);
        [DllImport(@"./engine")] private static extern short GetTileXEntity(IntPtr entity);
        [DllImport(@"./engine")] private static extern short GetTileYEntity(IntPtr entity);
        [DllImport(@"./engine")] private static extern void SetTileXEntity(IntPtr entity, short x);
        [DllImport(@"./engine")] private static extern void SetTileYEntity(IntPtr entity, short y);
        [DllImport(@"./engine")] private static extern void SetTextureEntity(IntPtr entity, string path);
        [DllImport(@"./engine")] private static extern void RenderEntity(IntPtr entity);
        [DllImport(@"./engine")] private static extern IntPtr DeleteEntity(IntPtr entity);

        public ushort Width
        {
            get
            {
                return GetWidthEntity(_entity);
            }

            set
            {
                SetWidthEntity(_entity, value);
            }
        }

        public ushort Height
        {
            get
            {
                return GetHeightEntity(_entity);
            }

            set
            {
                SetHeightEntity(_entity, value);
            }
        }

        public short X
        {
            get
            {
                return GetXEntity(_entity);
            }

            set
            {
                SetXEntity(_entity, value);
            }
        }

        public short Y
        {
            get
            {
                return GetYEntity(_entity);
            }

            set
            {
                SetYEntity(_entity, value);
            }
        }

        public ushort TileWidth
        {
            get
            {
                return GetTileWEntity(_entity);
            }

            set
            {
                SetTileWEntity(_entity, value);
            }
        }

        public ushort TileHeight
        {
            get
            {
                return GetTileHEntity(_entity);
            }

            set
            {
                SetTileHEntity(_entity, value);
            }
        }

        public short TileX
        {
            get
            {
                return GetTileXEntity(_entity);
            }

            set
            {
                SetTileXEntity(_entity, value);
            }
        }

        public short TileY
        {
            get
            {
                return GetTileYEntity(_entity);
            }

            set
            {
                SetTileYEntity(_entity, value);
            }
        }

        public string Texture
        {
            set
            {
                SetTextureEntity(_entity, value);
            }
        }

        public Entity()
        {
            _entity = CreateEntity();
        }

        public Entity(Rect geometry) : this()
        {
            SetSize(geometry.w, geometry.h);
            SetPosition(geometry.x, geometry.y);
        }

        public Entity((ushort, ushort, short, short) geometry) : this()
        {
            SetSize(geometry.Item1, geometry.Item2);
            SetPosition(geometry.Item3, geometry.Item4);
        }

        public Entity(Rect geometry, string texturePath) : this(geometry)
        {
            Texture = texturePath;
        }

        public Entity((ushort, ushort, short, short) geometry, string texturePath) : this(geometry)
        {
            Texture = texturePath;
        }

        public Entity(Rect geometry, string texturePath, Rect tile) : this(geometry, texturePath)
        {
            SetTileSize(tile.w, tile.h);
            SetTilePosition(tile.x, tile.y);
        }

        public Entity((ushort, ushort, short, short) geometry, string texturePath, (ushort, ushort, short, short) tile) : this(geometry, texturePath)
        {
            SetTileSize(tile.Item1, tile.Item2);
            SetTilePosition(tile.Item3, tile.Item4);
        }

        public void SetSize(ushort w, ushort h)
        {
            Width = w;
            Height = h;
        }

        public void SetPosition(short x, short y)
        {
            X = x;
            Y = y;
        }

        public void SetTileSize(ushort w, ushort h)
        {
            TileWidth = w;
            TileHeight = h;
        }

        public void SetTilePosition(short x, short y)
        {
            TileX = x;
            TileY = y;
        }

        public void Render()
        {
            RenderEntity(_entity);
        }

        ~Entity()
        {
            DeleteEntity(_entity);
        }
    }
}