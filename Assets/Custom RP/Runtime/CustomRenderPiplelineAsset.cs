using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "Rendering/Custom Render Asset")]
public class CustomRenderPiplelineAsset : RenderPipelineAsset
{

    [SerializeField]
	bool useDynamicBatching = true, useGPUInstancing = true, useSRPBatcher = true;

	protected override RenderPipeline CreatePipeline () {
		return new CustomRenderPipeline(
			useDynamicBatching, useGPUInstancing, useSRPBatcher
		);
	}
}
