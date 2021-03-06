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

namespace BasicRigidBodyProject
{
    public class MyScene : Scene
    {
        protected override void CreateScene()
        {            
            RenderManager.DebugLines = true;
            FreeCamera camera = new FreeCamera("MainCamera", new Vector3(0, 10, 20), Vector3.Zero)
            {
                BackgroundColor = Color.CornflowerBlue,
            };
            EntityManager.Add(camera.Entity);            

            Entity ground = new Entity("Ground")
             .AddComponent(new Transform3D() { Position = new Vector3(0, -1, 0), Scale = new Vector3(100, 1, 100) })
             .AddComponent(new BoxCollider())
             .AddComponent(Model.CreateCube())
             .AddComponent(new RigidBody3D() { IsKinematic = true })
             .AddComponent(new MaterialsMap())
             .AddComponent(new ModelRenderer());

            EntityManager.Add(ground);
            int i = 0;
            int j = 0;
            WaveServices.TimerFactory.CreateTimer("CreateRigidBody", TimeSpan.FromSeconds(0.2f),
                () =>
                {
                    j = ++j % 3;
                    switch (j)
                    {
                        case 0:
                            CreateBox("Box" + i, new Vector3(0.1f, 15, 0));
                            break;
                        case 1:
                            CreateSphere("Sphere" + i, new Vector3(i * 0.01f, 18, 0));
                            break;
                        case 2:
                            CreateCapsule("Capusle" + i, new Vector3(0, 20, 0));
                            break;
                        default:
                            throw new InvalidCastException("Invalid type.");
                    }

                    i++;
                    if (i == 50)
                    {
                        WaveServices.TimerFactory.RemoveTimer("CreateRigidBody");
                    }
                }, true);


        }

        private void CreateBox(string name, Vector3 position)
        {
            Entity primitive = new Entity(name)
                .AddComponent(new Transform3D() { Position = position })
                .AddComponent(new BoxCollider())
                .AddComponent(Model.CreateCube())
                .AddComponent(new RigidBody3D())
                .AddComponent(new MaterialsMap())
                .AddComponent(new ModelRenderer());

            EntityManager.Add(primitive);
        }

        private void CreateCapsule(string name, Vector3 position)
        {
            Entity primitive = new Entity(name)
                .AddComponent(new Transform3D() { Position = position })
                .AddComponent(new CapsuleCollider())
                .AddComponent(Model.CreateCapsule())
                .AddComponent(new RigidBody3D())
                .AddComponent(new MaterialsMap())
                .AddComponent(new ModelRenderer());

            EntityManager.Add(primitive);
        }

        private void CreateSphere(string name, Vector3 position)
        {
            Entity primitive = new Entity(name)
                .AddComponent(new Transform3D() { Position = position })
                .AddComponent(new SphereCollider())
                .AddComponent(Model.CreateSphere())
                .AddComponent(new RigidBody3D())
                .AddComponent(new MaterialsMap())
                .AddComponent(new ModelRenderer());

            EntityManager.Add(primitive);
        }

        private Color GetRandomColor()
        {
            var random = WaveServices.Random;
            return new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble(), 1f);
        }
    }
}
