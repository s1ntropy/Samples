// Copyright (C) 2014 Weekend Game Studio
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.

#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics3D;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;
#endregion

namespace PrimitivesProject
{
    public class MyScene : Scene
    {
        protected override void CreateScene()
        {
            ViewCamera camera = new ViewCamera("MainCamera", new Vector3(0, 0, 3), Vector3.Zero);
            camera.BackgroundColor = Color.CornflowerBlue;
            EntityManager.Add(camera.Entity);         

            Entity primitive = new Entity("Primitive")
                .AddComponent(new Spinner() { AxisTotalIncreases = new Vector3(1f, 2f, 1f) })
                .AddComponent(new Transform3D())
                .AddComponent(Model.CreateTeapot())
                .AddComponent(new BoxCollider())
                .AddComponent(new ChangeModel())
                .AddComponent(new MaterialsMap())//new BasicMaterial(Color.White)))
                .AddComponent(new ModelRenderer());

            EntityManager.Add(primitive);
        }     
    }
}
