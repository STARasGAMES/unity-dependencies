
#if !UNITY_2020_1_OR_NEWER
using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace SaG.Dependencies
{
	[Serializable]
	public sealed class Dependency_Transform : Dependency<Transform> { }

	[Serializable]
	public sealed class Dependency_Rigidbody : Dependency<Rigidbody> { }

	[Serializable]
	public sealed class Dependency_Collider : Dependency<Collider> { }

	[Serializable]
	public sealed class Dependency_BoxCollider : Dependency<BoxCollider> { }

	[Serializable]
	public sealed class Dependency_SphereCollider : Dependency<SphereCollider> { }

	[Serializable]
	public sealed class Dependency_CapsuleCollider : Dependency<CapsuleCollider> { }

	[Serializable]
	public sealed class Dependency_MeshCollider : Dependency<MeshCollider> { }

	[Serializable]
	public sealed class Dependency_Rigidbody2D : Dependency<Rigidbody2D> { }

	[Serializable]
	public sealed class Dependency_Collider2D : Dependency<Collider2D> { }

	[Serializable]
	public sealed class Dependency_BoxCollider2D : Dependency<BoxCollider2D> { }

	[Serializable]
	public sealed class Dependency_CircleCollider2D : Dependency<CircleCollider2D> { }

	[Serializable]
	public sealed class Dependency_CapsuleCollider2D : Dependency<CapsuleCollider2D> { }

	[Serializable]
	public sealed class Dependency_CompositeCollider2D : Dependency<CompositeCollider2D> { }

	[Serializable]
	public sealed class Dependency_EdgeCollider2D : Dependency<EdgeCollider2D> { }

	[Serializable]
	public sealed class Dependency_PolygonCollider2D : Dependency<PolygonCollider2D> { }

	[Serializable]
	public sealed class Dependency_Animation : Dependency<Animation> { }

	[Serializable]
	public sealed class Dependency_Animator : Dependency<Animator> { }

	[Serializable]
	public sealed class Dependency_Light : Dependency<Light> { }

	[Serializable]
	public sealed class Dependency_Camera : Dependency<Camera> { }

	[Serializable]
	public sealed class Dependency_LODGroup : Dependency<LODGroup> { }

	[Serializable]
	public sealed class Dependency_Renderer : Dependency<Renderer> { }

	[Serializable]
	public sealed class Dependency_ParticleSystem : Dependency<ParticleSystem> { }

	[Serializable]
	public sealed class Dependency_TrailRenderer : Dependency<TrailRenderer> { }

	[Serializable]
	public sealed class Dependency_LineRenderer : Dependency<LineRenderer> { }

	[Serializable]
	public sealed class Dependency_MeshFilter : Dependency<MeshFilter> { }

	[Serializable]
	public sealed class Dependency_MeshRenderer : Dependency<MeshRenderer> { }

	[Serializable]
	public sealed class Dependency_SkinnedMeshRenderer : Dependency<SkinnedMeshRenderer> { }

	[Serializable]
	public sealed class Dependency_AudioSource : Dependency<AudioSource> { }

	[Serializable]
	public sealed class Dependency_AudioReverbZone : Dependency<AudioReverbZone> { }

	[Serializable]
	public sealed class Dependency_CharacterController : Dependency<CharacterController> { }
	
	[Serializable]
	public sealed class Dependency_Text : Dependency<Text> { }

	[Serializable]
	public sealed class Dependency_Button : Dependency<Button> { }

	[Serializable]
	public sealed class Dependency_Image : Dependency<Image> { }

#if TMP
	[Serializable]
	public sealed class Dependency_TPM_Text : Dependency<TMPro.TMP_Text> { }
	
	[Serializable]
	public sealed class Dependency_TextMeshPro : Dependency<TMPro.TextMeshPro> { }

	[Serializable]
	public sealed class Dependency_TextMeshProUGUI : Dependency<TMPro.TextMeshProUGUI> { }
#endif
	
	[Serializable]
	public sealed class Dependency_PlayableDirector : Dependency<PlayableDirector> { }

	[Serializable]
	public sealed class Dependency_RectTransform : Dependency<RectTransform> { }

	[Serializable]
	public sealed class Dependency_Canvas : Dependency<Canvas> { }

	[Serializable]
	public sealed class Dependency_CanvasGroup : Dependency<CanvasGroup> { }
}
#endif
