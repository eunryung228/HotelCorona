using System;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGDatabase;

//=============================================================
//||                   Generated by BansheeGz Code Generator ||
//=============================================================

namespace BansheeGz.BGDatabase.Example
{
	[AddComponentMenu("BansheeGz/Generated/BGM_Player")]
	public partial class BGM_Player : BGEntityGo
	{
		public override BGMetaEntity MetaConstraint
		{
			get
			{
				return MetaDefault;
			}
		}
		private static BansheeGz.BGDatabase.BGMetaRow _metaDefault;
		public static BansheeGz.BGDatabase.BGMetaRow MetaDefault
		{
			get
			{
				if(_metaDefault==null || _metaDefault.IsDeleted) _metaDefault=BGRepo.I.GetMeta<BansheeGz.BGDatabase.BGMetaRow>(new BGId(5497940596274453431,8776586752841371551));
				return _metaDefault;
			}
		}
		public static BansheeGz.BGDatabase.BGRepoEvents Events
		{
			get
			{
				return BGRepo.I.Events;
			}
		}
		public System.String m_name
		{
			get
			{
				return _m_name[Entity.Index];
			}
			set
			{
				_m_name[Entity.Index] = value;
			}
		}
		public System.Int32 m_gold
		{
			get
			{
				return _m_gold[Entity.Index];
			}
			set
			{
				_m_gold[Entity.Index] = value;
			}
		}
		public UnityEngine.Vector3 m_position
		{
			get
			{
				return _m_position[Entity.Index];
			}
			set
			{
				_m_position[Entity.Index] = value;
			}
		}
		public UnityEngine.Quaternion m_rotation
		{
			get
			{
				return _m_rotation[Entity.Index];
			}
			set
			{
				_m_rotation[Entity.Index] = value;
			}
		}
		public BansheeGz.BGDatabase.Example.BGE_Scene m_scene
		{
			get
			{
				return (BansheeGz.BGDatabase.Example.BGE_Scene) _m_scene[Entity.Index];
			}
			set
			{
				_m_scene[Entity.Index] = value;
			}
		}
		private static BansheeGz.BGDatabase.BGFieldEntityName __m_name;
		public static BansheeGz.BGDatabase.BGFieldEntityName _m_name
		{
			get
			{
				if(__m_name==null || __m_name.IsDeleted) __m_name=(BansheeGz.BGDatabase.BGFieldEntityName) MetaDefault.GetField(new BGId(5063533677370453642,590874763744547202));
				return __m_name;
			}
		}
		private static BansheeGz.BGDatabase.BGFieldInt __m_gold;
		public static BansheeGz.BGDatabase.BGFieldInt _m_gold
		{
			get
			{
				if(__m_gold==null || __m_gold.IsDeleted) __m_gold=(BansheeGz.BGDatabase.BGFieldInt) MetaDefault.GetField(new BGId(5284355689219626041,9357458533315117725));
				return __m_gold;
			}
		}
		private static BansheeGz.BGDatabase.BGFieldVector3 __m_position;
		public static BansheeGz.BGDatabase.BGFieldVector3 _m_position
		{
			get
			{
				if(__m_position==null || __m_position.IsDeleted) __m_position=(BansheeGz.BGDatabase.BGFieldVector3) MetaDefault.GetField(new BGId(4869784971887315692,9568465348516374174));
				return __m_position;
			}
		}
		private static BansheeGz.BGDatabase.BGFieldQuaternion __m_rotation;
		public static BansheeGz.BGDatabase.BGFieldQuaternion _m_rotation
		{
			get
			{
				if(__m_rotation==null || __m_rotation.IsDeleted) __m_rotation=(BansheeGz.BGDatabase.BGFieldQuaternion) MetaDefault.GetField(new BGId(4970772665394671918,1241744588942929806));
				return __m_rotation;
			}
		}
		private static BansheeGz.BGDatabase.BGFieldRelationSingle __m_scene;
		public static BansheeGz.BGDatabase.BGFieldRelationSingle _m_scene
		{
			get
			{
				if(__m_scene==null || __m_scene.IsDeleted) __m_scene=(BansheeGz.BGDatabase.BGFieldRelationSingle) MetaDefault.GetField(new BGId(4654508477061466319,398411287537504692));
				return __m_scene;
			}
		}
	}
}
