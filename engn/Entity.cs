using System;
using System.Runtime.InteropServices;

namespace engn
{
    public class Entity
    {
        private readonly IntPtr _entity;

        [DllImport(@"./engine")] private static extern IntPtr CreateEntity();
        [DllImport(@"./engine")] private static extern ushort GetWidth(IntPtr entity);
        [DllImport(@"./engine")] private static extern ushort GetHeight(IntPtr entity);
        [DllImport(@"./engine")] private static extern void SetWidth(IntPtr entity, ushort w);
        [DllImport(@"./engine")] private static extern void SetHeight(IntPtr entity, ushort w);
        [DllImport(@"./engine")] private static extern short GetX(IntPtr entity);
        [DllImport(@"./engine")] private static extern short GetY(IntPtr entity);
        [DllImport(@"./engine")] private static extern short SetX(IntPtr entity, short x);
        [DllImport(@"./engine")] private static extern short SetY(IntPtr entity, short y);
        [DllImport(@"./engine")] private static extern short SetTexture(IntPtr entity, string path);
        [DllImport(@"./engine")] private static extern void RenderEntity(IntPtr entity);
        [DllImport(@"./engine")] private static extern IntPtr DeleteEntity(IntPtr entity);

        public ushort Width
        {
            get
            {
                return GetWidth(_entity);
            }

            set
            {
                SetWidth(_entity, value);
            }
        }

        public ushort Height
        {
            get
            {
                return GetHeight(_entity);
            }

            set
            {
                SetHeight(_entity, value);
            }
        }

        public short X
        {
            get
            {
                return GetX(_entity);
            }

            set
            {
                SetX(_entity, value);
            }
        }

        public short Y
        {
            get
            {
                return GetY(_entity);
            }

            set
            {
                SetY(_entity, value);
            }
        }

        public string Texture
        {
            set
            {
                SetTexture(_entity, value);
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

        public Entity(string texturePath, Rect geometry) : this(geometry)
        {
            Texture = texturePath;
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