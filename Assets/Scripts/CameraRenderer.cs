using UnityEngine;
using UnityEngine.Rendering;

public class CameraRenderer 
{
    ScriptableRenderContext context;
    Camera camera;

    const string bufferName = "Render Camera";

    CommandBuffer buffer = new CommandBuffer {
        name = bufferName
    };
    public void Render (ScriptableRenderContext context, Camera camera) {
        this.context = context;
        this.camera = camera;
        if (!Cull()) {
            return;
        }
        
        Setup();
        DrawVisibleGeometry();
        Submit();
    }

    void Submit () {
        buffer.EndSample(bufferName);
        ExecuteBuffer();
        context.Submit();
    }

    void DrawVisibleGeometry () {
        context.DrawSkybox(camera);
    }
    
    void Setup () {
        context.SetupCameraProperties(camera);
        buffer.ClearRenderTarget(true, true, Color.clear);
        buffer.BeginSample(bufferName);
        ExecuteBuffer();
       
    }
    
    void ExecuteBuffer () {
        context.ExecuteCommandBuffer(buffer);
        buffer.Clear();
    }
    
    bool Cull () {
        if (camera.TryGetCullingParameters(out ScriptableCullingParameters p)) {
            return true;
        }
        return false;
    }
}
