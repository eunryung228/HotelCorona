using System;
using System.Collections.Generic;
using BansheeGz.BGDatabase;

//=============================================================
//||                   Generated by BansheeGz Code Generator ||
//=============================================================

#pragma warning disable 414

		//=============================================================
		//||                   Generated by BansheeGz Code Generator ||
		//=============================================================

		public partial class TBL_CHARACTER : BGEntity
		{

			//=============================================================
			//||                   Generated by BansheeGz Code Generator ||
			//=============================================================

			public class Factory : BGEntity.EntityFactory
			{
				public BGEntity NewEntity(BGMetaEntity meta)
				{
					return new TBL_CHARACTER(meta);
				}
				public BGEntity NewEntity(BGMetaEntity meta, BGId id)
				{
					return new TBL_CHARACTER(meta, id);
				}
			}
			private static BansheeGz.BGDatabase.BGMetaRow _metaDefault;
			public static BansheeGz.BGDatabase.BGMetaRow MetaDefault
			{
				get
				{
					if(_metaDefault==null || _metaDefault.IsDeleted) _metaDefault=BGRepo.I.GetMeta<BansheeGz.BGDatabase.BGMetaRow>(new BGId(5017544333464198542,8821115878147373999));
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
			private static readonly List<BGEntity> _find_Entities_Result = new List<BGEntity>();
			public static int CountEntities
			{
				get
				{
					return MetaDefault.CountEntities;
				}
			}
			public System.String name
			{
				get
				{
					return _name[Index];
				}
				set
				{
					_name[Index] = value;
				}
			}
			public System.Single maxFood
			{
				get
				{
					return _maxFood[Index];
				}
				set
				{
					_maxFood[Index] = value;
				}
			}
			public System.Single maxHealth
			{
				get
				{
					return _maxHealth[Index];
				}
				set
				{
					_maxHealth[Index] = value;
				}
			}
			public System.Single maxMental
			{
				get
				{
					return _maxMental[Index];
				}
				set
				{
					_maxMental[Index] = value;
				}
			}
			public System.Single maxLone
			{
				get
				{
					return _maxLone[Index];
				}
				set
				{
					_maxLone[Index] = value;
				}
			}
			public System.Single skillCoolDown
			{
				get
				{
					return _skillCoolDown[Index];
				}
				set
				{
					_skillCoolDown[Index] = value;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldEntityName _ufle12jhs77_name;
			public static BansheeGz.BGDatabase.BGFieldEntityName _name
			{
				get
				{
					if(_ufle12jhs77_name==null || _ufle12jhs77_name.IsDeleted) _ufle12jhs77_name=(BansheeGz.BGDatabase.BGFieldEntityName) MetaDefault.GetField(new BGId(4846555596199213371,248167139628069043));
					return _ufle12jhs77_name;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_maxFood;
			public static BansheeGz.BGDatabase.BGFieldFloat _maxFood
			{
				get
				{
					if(_ufle12jhs77_maxFood==null || _ufle12jhs77_maxFood.IsDeleted) _ufle12jhs77_maxFood=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(4904864690131797066,8139986306665826994));
					return _ufle12jhs77_maxFood;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_maxHealth;
			public static BansheeGz.BGDatabase.BGFieldFloat _maxHealth
			{
				get
				{
					if(_ufle12jhs77_maxHealth==null || _ufle12jhs77_maxHealth.IsDeleted) _ufle12jhs77_maxHealth=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(4897525801282744621,9908843984320086408));
					return _ufle12jhs77_maxHealth;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_maxMental;
			public static BansheeGz.BGDatabase.BGFieldFloat _maxMental
			{
				get
				{
					if(_ufle12jhs77_maxMental==null || _ufle12jhs77_maxMental.IsDeleted) _ufle12jhs77_maxMental=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5407151573568413580,4746363068103038094));
					return _ufle12jhs77_maxMental;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_maxLone;
			public static BansheeGz.BGDatabase.BGFieldFloat _maxLone
			{
				get
				{
					if(_ufle12jhs77_maxLone==null || _ufle12jhs77_maxLone.IsDeleted) _ufle12jhs77_maxLone=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5373077151468256591,1483170474168171401));
					return _ufle12jhs77_maxLone;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_skillCoolDown;
			public static BansheeGz.BGDatabase.BGFieldFloat _skillCoolDown
			{
				get
				{
					if(_ufle12jhs77_skillCoolDown==null || _ufle12jhs77_skillCoolDown.IsDeleted) _ufle12jhs77_skillCoolDown=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(4953939515187772883,16634826489169752999));
					return _ufle12jhs77_skillCoolDown;
				}
			}
			private static readonly TBL_CHARACTER.Factory _factory0_PFS = new TBL_CHARACTER.Factory();
			private static readonly TBL_SKILL.Factory _factory1_PFS = new TBL_SKILL.Factory();
			private static readonly TBL_DATA.Factory _factory2_PFS = new TBL_DATA.Factory();
			public TBL_CHARACTER() : base(MetaDefault)
			{
			}
			public TBL_CHARACTER(BGId id) : base(MetaDefault, id)
			{
			}
			public TBL_CHARACTER(BGMetaEntity meta) : base(meta)
			{
			}
			public TBL_CHARACTER(BGMetaEntity meta, BGId id) : base(meta, id)
			{
			}
			public static TBL_CHARACTER FindEntity(Predicate<TBL_CHARACTER> filter)
			{
				return MetaDefault.FindEntity(entity => filter==null || filter((TBL_CHARACTER) entity)) as TBL_CHARACTER;
			}
			public static List<TBL_CHARACTER> FindEntities(Predicate<TBL_CHARACTER> filter, List<TBL_CHARACTER> result=null, Comparison<TBL_CHARACTER> sort=null)
			{
				result = result ?? new List<TBL_CHARACTER>();
				_find_Entities_Result.Clear();
				MetaDefault.FindEntities(filter == null ? (Predicate<BGEntity>) null: e => filter((TBL_CHARACTER) e), _find_Entities_Result, sort == null ? (Comparison<BGEntity>) null : (e1, e2) => sort((TBL_CHARACTER) e1, (TBL_CHARACTER) e2));
				if (_find_Entities_Result.Count != 0)
				{
					for (var i = 0; i < _find_Entities_Result.Count; i++) result.Add((TBL_CHARACTER) _find_Entities_Result[i]);
					_find_Entities_Result.Clear();
				}
				return result;
			}
			public static void ForEachEntity(Action<TBL_CHARACTER> action, Predicate<TBL_CHARACTER> filter=null, Comparison<TBL_CHARACTER> sort=null)
			{
				MetaDefault.ForEachEntity(entity => action((TBL_CHARACTER) entity), filter == null ? null : (Predicate<BGEntity>) (entity => filter((TBL_CHARACTER) entity)), sort==null?(Comparison<BGEntity>) null:(e1,e2) => sort((TBL_CHARACTER)e1,(TBL_CHARACTER)e2));
			}
			public static TBL_CHARACTER GetEntity(BGId entityId)
			{
				return (TBL_CHARACTER) MetaDefault.GetEntity(entityId);
			}
			public static TBL_CHARACTER GetEntity(int index)
			{
				return (TBL_CHARACTER) MetaDefault[index];
			}
			public static TBL_CHARACTER GetEntity(string entityName)
			{
				return (TBL_CHARACTER) MetaDefault.GetEntity(entityName);
			}
			public static TBL_CHARACTER NewEntity()
			{
				return (TBL_CHARACTER) MetaDefault.NewEntity();
			}
		}


		//=============================================================
		//||                   Generated by BansheeGz Code Generator ||
		//=============================================================

		public partial class TBL_SKILL : BGEntity
		{

			//=============================================================
			//||                   Generated by BansheeGz Code Generator ||
			//=============================================================

			public class Factory : BGEntity.EntityFactory
			{
				public BGEntity NewEntity(BGMetaEntity meta)
				{
					return new TBL_SKILL(meta);
				}
				public BGEntity NewEntity(BGMetaEntity meta, BGId id)
				{
					return new TBL_SKILL(meta, id);
				}
			}
			private static BansheeGz.BGDatabase.BGMetaRow _metaDefault;
			public static BansheeGz.BGDatabase.BGMetaRow MetaDefault
			{
				get
				{
					if(_metaDefault==null || _metaDefault.IsDeleted) _metaDefault=BGRepo.I.GetMeta<BansheeGz.BGDatabase.BGMetaRow>(new BGId(5072221567557324940,10294891115789599395));
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
			private static readonly List<BGEntity> _find_Entities_Result = new List<BGEntity>();
			public static int CountEntities
			{
				get
				{
					return MetaDefault.CountEntities;
				}
			}
			public System.String name
			{
				get
				{
					return _name[Index];
				}
				set
				{
					_name[Index] = value;
				}
			}
			public System.Single foodAddAmount
			{
				get
				{
					return _foodAddAmount[Index];
				}
				set
				{
					_foodAddAmount[Index] = value;
				}
			}
			public System.Single healthAddAmount
			{
				get
				{
					return _healthAddAmount[Index];
				}
				set
				{
					_healthAddAmount[Index] = value;
				}
			}
			public System.Single mentalAddAmount
			{
				get
				{
					return _mentalAddAmount[Index];
				}
				set
				{
					_mentalAddAmount[Index] = value;
				}
			}
			public System.Single loneAddAmount
			{
				get
				{
					return _loneAddAmount[Index];
				}
				set
				{
					_loneAddAmount[Index] = value;
				}
			}
			public System.Single confirmRate
			{
				get
				{
					return _confirmRate[Index];
				}
				set
				{
					_confirmRate[Index] = value;
				}
			}
			public System.Single escapeRate
			{
				get
				{
					return _escapeRate[Index];
				}
				set
				{
					_escapeRate[Index] = value;
				}
			}
			public System.Int32 reaminUseAmount
			{
				get
				{
					return _reaminUseAmount[Index];
				}
				set
				{
					_reaminUseAmount[Index] = value;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldEntityName _ufle12jhs77_name;
			public static BansheeGz.BGDatabase.BGFieldEntityName _name
			{
				get
				{
					if(_ufle12jhs77_name==null || _ufle12jhs77_name.IsDeleted) _ufle12jhs77_name=(BansheeGz.BGDatabase.BGFieldEntityName) MetaDefault.GetField(new BGId(5703157086491013357,10658899914776718216));
					return _ufle12jhs77_name;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_foodAddAmount;
			public static BansheeGz.BGDatabase.BGFieldFloat _foodAddAmount
			{
				get
				{
					if(_ufle12jhs77_foodAddAmount==null || _ufle12jhs77_foodAddAmount.IsDeleted) _ufle12jhs77_foodAddAmount=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5458280218120368024,2625866078258192034));
					return _ufle12jhs77_foodAddAmount;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_healthAddAmount;
			public static BansheeGz.BGDatabase.BGFieldFloat _healthAddAmount
			{
				get
				{
					if(_ufle12jhs77_healthAddAmount==null || _ufle12jhs77_healthAddAmount.IsDeleted) _ufle12jhs77_healthAddAmount=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5574355879986861132,3944690853622169265));
					return _ufle12jhs77_healthAddAmount;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_mentalAddAmount;
			public static BansheeGz.BGDatabase.BGFieldFloat _mentalAddAmount
			{
				get
				{
					if(_ufle12jhs77_mentalAddAmount==null || _ufle12jhs77_mentalAddAmount.IsDeleted) _ufle12jhs77_mentalAddAmount=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5466044135673549417,15914137018702981526));
					return _ufle12jhs77_mentalAddAmount;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_loneAddAmount;
			public static BansheeGz.BGDatabase.BGFieldFloat _loneAddAmount
			{
				get
				{
					if(_ufle12jhs77_loneAddAmount==null || _ufle12jhs77_loneAddAmount.IsDeleted) _ufle12jhs77_loneAddAmount=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5373686473479347370,4001342861935115164));
					return _ufle12jhs77_loneAddAmount;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_confirmRate;
			public static BansheeGz.BGDatabase.BGFieldFloat _confirmRate
			{
				get
				{
					if(_ufle12jhs77_confirmRate==null || _ufle12jhs77_confirmRate.IsDeleted) _ufle12jhs77_confirmRate=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(4870378340564890740,13113063873739805867));
					return _ufle12jhs77_confirmRate;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_escapeRate;
			public static BansheeGz.BGDatabase.BGFieldFloat _escapeRate
			{
				get
				{
					if(_ufle12jhs77_escapeRate==null || _ufle12jhs77_escapeRate.IsDeleted) _ufle12jhs77_escapeRate=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5218238450686814097,299807575323991970));
					return _ufle12jhs77_escapeRate;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_reaminUseAmount;
			public static BansheeGz.BGDatabase.BGFieldInt _reaminUseAmount
			{
				get
				{
					if(_ufle12jhs77_reaminUseAmount==null || _ufle12jhs77_reaminUseAmount.IsDeleted) _ufle12jhs77_reaminUseAmount=(BansheeGz.BGDatabase.BGFieldInt) MetaDefault.GetField(new BGId(5117451326227883384,13018578731968835761));
					return _ufle12jhs77_reaminUseAmount;
				}
			}
			private static readonly TBL_CHARACTER.Factory _factory0_PFS = new TBL_CHARACTER.Factory();
			private static readonly TBL_SKILL.Factory _factory1_PFS = new TBL_SKILL.Factory();
			private static readonly TBL_DATA.Factory _factory2_PFS = new TBL_DATA.Factory();
			public TBL_SKILL() : base(MetaDefault)
			{
			}
			public TBL_SKILL(BGId id) : base(MetaDefault, id)
			{
			}
			public TBL_SKILL(BGMetaEntity meta) : base(meta)
			{
			}
			public TBL_SKILL(BGMetaEntity meta, BGId id) : base(meta, id)
			{
			}
			public static TBL_SKILL FindEntity(Predicate<TBL_SKILL> filter)
			{
				return MetaDefault.FindEntity(entity => filter==null || filter((TBL_SKILL) entity)) as TBL_SKILL;
			}
			public static List<TBL_SKILL> FindEntities(Predicate<TBL_SKILL> filter, List<TBL_SKILL> result=null, Comparison<TBL_SKILL> sort=null)
			{
				result = result ?? new List<TBL_SKILL>();
				_find_Entities_Result.Clear();
				MetaDefault.FindEntities(filter == null ? (Predicate<BGEntity>) null: e => filter((TBL_SKILL) e), _find_Entities_Result, sort == null ? (Comparison<BGEntity>) null : (e1, e2) => sort((TBL_SKILL) e1, (TBL_SKILL) e2));
				if (_find_Entities_Result.Count != 0)
				{
					for (var i = 0; i < _find_Entities_Result.Count; i++) result.Add((TBL_SKILL) _find_Entities_Result[i]);
					_find_Entities_Result.Clear();
				}
				return result;
			}
			public static void ForEachEntity(Action<TBL_SKILL> action, Predicate<TBL_SKILL> filter=null, Comparison<TBL_SKILL> sort=null)
			{
				MetaDefault.ForEachEntity(entity => action((TBL_SKILL) entity), filter == null ? null : (Predicate<BGEntity>) (entity => filter((TBL_SKILL) entity)), sort==null?(Comparison<BGEntity>) null:(e1,e2) => sort((TBL_SKILL)e1,(TBL_SKILL)e2));
			}
			public static TBL_SKILL GetEntity(BGId entityId)
			{
				return (TBL_SKILL) MetaDefault.GetEntity(entityId);
			}
			public static TBL_SKILL GetEntity(int index)
			{
				return (TBL_SKILL) MetaDefault[index];
			}
			public static TBL_SKILL GetEntity(string entityName)
			{
				return (TBL_SKILL) MetaDefault.GetEntity(entityName);
			}
			public static TBL_SKILL NewEntity()
			{
				return (TBL_SKILL) MetaDefault.NewEntity();
			}
		}


		//=============================================================
		//||                   Generated by BansheeGz Code Generator ||
		//=============================================================

		public partial class TBL_DATA : BGEntity
		{

			//=============================================================
			//||                   Generated by BansheeGz Code Generator ||
			//=============================================================

			public class Factory : BGEntity.EntityFactory
			{
				public BGEntity NewEntity(BGMetaEntity meta)
				{
					return new TBL_DATA(meta);
				}
				public BGEntity NewEntity(BGMetaEntity meta, BGId id)
				{
					return new TBL_DATA(meta, id);
				}
			}
			private static BansheeGz.BGDatabase.BGMetaRow _metaDefault;
			public static BansheeGz.BGDatabase.BGMetaRow MetaDefault
			{
				get
				{
					if(_metaDefault==null || _metaDefault.IsDeleted) _metaDefault=BGRepo.I.GetMeta<BansheeGz.BGDatabase.BGMetaRow>(new BGId(4749178204971555397,8387912496114005124));
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
			private static readonly List<BGEntity> _find_Entities_Result = new List<BGEntity>();
			public static int CountEntities
			{
				get
				{
					return MetaDefault.CountEntities;
				}
			}
			public System.String name
			{
				get
				{
					return _name[Index];
				}
				set
				{
					_name[Index] = value;
				}
			}
			public System.Int32 newQuarantine
			{
				get
				{
					return _newQuarantine[Index];
				}
				set
				{
					_newQuarantine[Index] = value;
				}
			}
			public System.Single minFoodMulti
			{
				get
				{
					return _minFoodMulti[Index];
				}
				set
				{
					_minFoodMulti[Index] = value;
				}
			}
			public System.Single maxFoodMulti
			{
				get
				{
					return _maxFoodMulti[Index];
				}
				set
				{
					_maxFoodMulti[Index] = value;
				}
			}
			public System.Single minHealthMulti
			{
				get
				{
					return _minHealthMulti[Index];
				}
				set
				{
					_minHealthMulti[Index] = value;
				}
			}
			public System.Single maxHealthMulti
			{
				get
				{
					return _maxHealthMulti[Index];
				}
				set
				{
					_maxHealthMulti[Index] = value;
				}
			}
			public System.Single minMentalMulti
			{
				get
				{
					return _minMentalMulti[Index];
				}
				set
				{
					_minMentalMulti[Index] = value;
				}
			}
			public System.Single maxMentalMulti
			{
				get
				{
					return _maxMentalMulti[Index];
				}
				set
				{
					_maxMentalMulti[Index] = value;
				}
			}
			public System.Single minLoneMulti
			{
				get
				{
					return _minLoneMulti[Index];
				}
				set
				{
					_minLoneMulti[Index] = value;
				}
			}
			public System.Single maxLoneMulti
			{
				get
				{
					return _maxLoneMulti[Index];
				}
				set
				{
					_maxLoneMulti[Index] = value;
				}
			}
			public System.Single foodConsume
			{
				get
				{
					return _foodConsume[Index];
				}
				set
				{
					_foodConsume[Index] = value;
				}
			}
			public System.Single healthConsume
			{
				get
				{
					return _healthConsume[Index];
				}
				set
				{
					_healthConsume[Index] = value;
				}
			}
			public System.Single mentalConsume
			{
				get
				{
					return _mentalConsume[Index];
				}
				set
				{
					_mentalConsume[Index] = value;
				}
			}
			public System.Single loneConsume
			{
				get
				{
					return _loneConsume[Index];
				}
				set
				{
					_loneConsume[Index] = value;
				}
			}
			public System.Int32 minRemainConfirmDate
			{
				get
				{
					return _minRemainConfirmDate[Index];
				}
				set
				{
					_minRemainConfirmDate[Index] = value;
				}
			}
			public System.Int32 maxRemainConfirmDate
			{
				get
				{
					return _maxRemainConfirmDate[Index];
				}
				set
				{
					_maxRemainConfirmDate[Index] = value;
				}
			}
			public System.Single minConfirmRate
			{
				get
				{
					return _minConfirmRate[Index];
				}
				set
				{
					_minConfirmRate[Index] = value;
				}
			}
			public System.Single maxConfirmRate
			{
				get
				{
					return _maxConfirmRate[Index];
				}
				set
				{
					_maxConfirmRate[Index] = value;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldEntityName _ufle12jhs77_name;
			public static BansheeGz.BGDatabase.BGFieldEntityName _name
			{
				get
				{
					if(_ufle12jhs77_name==null || _ufle12jhs77_name.IsDeleted) _ufle12jhs77_name=(BansheeGz.BGDatabase.BGFieldEntityName) MetaDefault.GetField(new BGId(5585495291913876019,15116388902952799104));
					return _ufle12jhs77_name;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_newQuarantine;
			public static BansheeGz.BGDatabase.BGFieldInt _newQuarantine
			{
				get
				{
					if(_ufle12jhs77_newQuarantine==null || _ufle12jhs77_newQuarantine.IsDeleted) _ufle12jhs77_newQuarantine=(BansheeGz.BGDatabase.BGFieldInt) MetaDefault.GetField(new BGId(5748396231717261856,12692094512781103775));
					return _ufle12jhs77_newQuarantine;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_minFoodMulti;
			public static BansheeGz.BGDatabase.BGFieldFloat _minFoodMulti
			{
				get
				{
					if(_ufle12jhs77_minFoodMulti==null || _ufle12jhs77_minFoodMulti.IsDeleted) _ufle12jhs77_minFoodMulti=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5572535856152043302,7180064260108545461));
					return _ufle12jhs77_minFoodMulti;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_maxFoodMulti;
			public static BansheeGz.BGDatabase.BGFieldFloat _maxFoodMulti
			{
				get
				{
					if(_ufle12jhs77_maxFoodMulti==null || _ufle12jhs77_maxFoodMulti.IsDeleted) _ufle12jhs77_maxFoodMulti=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5743666337815730665,12844026721462512547));
					return _ufle12jhs77_maxFoodMulti;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_minHealthMulti;
			public static BansheeGz.BGDatabase.BGFieldFloat _minHealthMulti
			{
				get
				{
					if(_ufle12jhs77_minHealthMulti==null || _ufle12jhs77_minHealthMulti.IsDeleted) _ufle12jhs77_minHealthMulti=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(4924748433064254005,14893014406689536385));
					return _ufle12jhs77_minHealthMulti;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_maxHealthMulti;
			public static BansheeGz.BGDatabase.BGFieldFloat _maxHealthMulti
			{
				get
				{
					if(_ufle12jhs77_maxHealthMulti==null || _ufle12jhs77_maxHealthMulti.IsDeleted) _ufle12jhs77_maxHealthMulti=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5280898673321868105,12132485342408711074));
					return _ufle12jhs77_maxHealthMulti;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_minMentalMulti;
			public static BansheeGz.BGDatabase.BGFieldFloat _minMentalMulti
			{
				get
				{
					if(_ufle12jhs77_minMentalMulti==null || _ufle12jhs77_minMentalMulti.IsDeleted) _ufle12jhs77_minMentalMulti=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5425231392488751800,15145645112608236204));
					return _ufle12jhs77_minMentalMulti;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_maxMentalMulti;
			public static BansheeGz.BGDatabase.BGFieldFloat _maxMentalMulti
			{
				get
				{
					if(_ufle12jhs77_maxMentalMulti==null || _ufle12jhs77_maxMentalMulti.IsDeleted) _ufle12jhs77_maxMentalMulti=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(4856220063722892274,13917483064316818));
					return _ufle12jhs77_maxMentalMulti;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_minLoneMulti;
			public static BansheeGz.BGDatabase.BGFieldFloat _minLoneMulti
			{
				get
				{
					if(_ufle12jhs77_minLoneMulti==null || _ufle12jhs77_minLoneMulti.IsDeleted) _ufle12jhs77_minLoneMulti=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5435384631298995208,4371058083243260850));
					return _ufle12jhs77_minLoneMulti;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_maxLoneMulti;
			public static BansheeGz.BGDatabase.BGFieldFloat _maxLoneMulti
			{
				get
				{
					if(_ufle12jhs77_maxLoneMulti==null || _ufle12jhs77_maxLoneMulti.IsDeleted) _ufle12jhs77_maxLoneMulti=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5064354523960053507,12692877830436878752));
					return _ufle12jhs77_maxLoneMulti;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_foodConsume;
			public static BansheeGz.BGDatabase.BGFieldFloat _foodConsume
			{
				get
				{
					if(_ufle12jhs77_foodConsume==null || _ufle12jhs77_foodConsume.IsDeleted) _ufle12jhs77_foodConsume=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5241477579873045537,8054195755678160278));
					return _ufle12jhs77_foodConsume;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_healthConsume;
			public static BansheeGz.BGDatabase.BGFieldFloat _healthConsume
			{
				get
				{
					if(_ufle12jhs77_healthConsume==null || _ufle12jhs77_healthConsume.IsDeleted) _ufle12jhs77_healthConsume=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5309293628477986890,16609183939450348423));
					return _ufle12jhs77_healthConsume;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_mentalConsume;
			public static BansheeGz.BGDatabase.BGFieldFloat _mentalConsume
			{
				get
				{
					if(_ufle12jhs77_mentalConsume==null || _ufle12jhs77_mentalConsume.IsDeleted) _ufle12jhs77_mentalConsume=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(4845870025009882173,18424310206510858646));
					return _ufle12jhs77_mentalConsume;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_loneConsume;
			public static BansheeGz.BGDatabase.BGFieldFloat _loneConsume
			{
				get
				{
					if(_ufle12jhs77_loneConsume==null || _ufle12jhs77_loneConsume.IsDeleted) _ufle12jhs77_loneConsume=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5126780611046278641,13611182767049129613));
					return _ufle12jhs77_loneConsume;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_minRemainConfirmDate;
			public static BansheeGz.BGDatabase.BGFieldInt _minRemainConfirmDate
			{
				get
				{
					if(_ufle12jhs77_minRemainConfirmDate==null || _ufle12jhs77_minRemainConfirmDate.IsDeleted) _ufle12jhs77_minRemainConfirmDate=(BansheeGz.BGDatabase.BGFieldInt) MetaDefault.GetField(new BGId(5569804470578609191,10450431442601021843));
					return _ufle12jhs77_minRemainConfirmDate;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldInt _ufle12jhs77_maxRemainConfirmDate;
			public static BansheeGz.BGDatabase.BGFieldInt _maxRemainConfirmDate
			{
				get
				{
					if(_ufle12jhs77_maxRemainConfirmDate==null || _ufle12jhs77_maxRemainConfirmDate.IsDeleted) _ufle12jhs77_maxRemainConfirmDate=(BansheeGz.BGDatabase.BGFieldInt) MetaDefault.GetField(new BGId(4785815542242962077,2917956962569713335));
					return _ufle12jhs77_maxRemainConfirmDate;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_minConfirmRate;
			public static BansheeGz.BGDatabase.BGFieldFloat _minConfirmRate
			{
				get
				{
					if(_ufle12jhs77_minConfirmRate==null || _ufle12jhs77_minConfirmRate.IsDeleted) _ufle12jhs77_minConfirmRate=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5193366495866261401,5142301235395356548));
					return _ufle12jhs77_minConfirmRate;
				}
			}
			private static BansheeGz.BGDatabase.BGFieldFloat _ufle12jhs77_maxConfirmRate;
			public static BansheeGz.BGDatabase.BGFieldFloat _maxConfirmRate
			{
				get
				{
					if(_ufle12jhs77_maxConfirmRate==null || _ufle12jhs77_maxConfirmRate.IsDeleted) _ufle12jhs77_maxConfirmRate=(BansheeGz.BGDatabase.BGFieldFloat) MetaDefault.GetField(new BGId(5486123904841492764,15476280909132720038));
					return _ufle12jhs77_maxConfirmRate;
				}
			}
			private static readonly TBL_CHARACTER.Factory _factory0_PFS = new TBL_CHARACTER.Factory();
			private static readonly TBL_SKILL.Factory _factory1_PFS = new TBL_SKILL.Factory();
			private static readonly TBL_DATA.Factory _factory2_PFS = new TBL_DATA.Factory();
			public TBL_DATA() : base(MetaDefault)
			{
			}
			public TBL_DATA(BGId id) : base(MetaDefault, id)
			{
			}
			public TBL_DATA(BGMetaEntity meta) : base(meta)
			{
			}
			public TBL_DATA(BGMetaEntity meta, BGId id) : base(meta, id)
			{
			}
			public static TBL_DATA FindEntity(Predicate<TBL_DATA> filter)
			{
				return MetaDefault.FindEntity(entity => filter==null || filter((TBL_DATA) entity)) as TBL_DATA;
			}
			public static List<TBL_DATA> FindEntities(Predicate<TBL_DATA> filter, List<TBL_DATA> result=null, Comparison<TBL_DATA> sort=null)
			{
				result = result ?? new List<TBL_DATA>();
				_find_Entities_Result.Clear();
				MetaDefault.FindEntities(filter == null ? (Predicate<BGEntity>) null: e => filter((TBL_DATA) e), _find_Entities_Result, sort == null ? (Comparison<BGEntity>) null : (e1, e2) => sort((TBL_DATA) e1, (TBL_DATA) e2));
				if (_find_Entities_Result.Count != 0)
				{
					for (var i = 0; i < _find_Entities_Result.Count; i++) result.Add((TBL_DATA) _find_Entities_Result[i]);
					_find_Entities_Result.Clear();
				}
				return result;
			}
			public static void ForEachEntity(Action<TBL_DATA> action, Predicate<TBL_DATA> filter=null, Comparison<TBL_DATA> sort=null)
			{
				MetaDefault.ForEachEntity(entity => action((TBL_DATA) entity), filter == null ? null : (Predicate<BGEntity>) (entity => filter((TBL_DATA) entity)), sort==null?(Comparison<BGEntity>) null:(e1,e2) => sort((TBL_DATA)e1,(TBL_DATA)e2));
			}
			public static TBL_DATA GetEntity(BGId entityId)
			{
				return (TBL_DATA) MetaDefault.GetEntity(entityId);
			}
			public static TBL_DATA GetEntity(int index)
			{
				return (TBL_DATA) MetaDefault[index];
			}
			public static TBL_DATA GetEntity(string entityName)
			{
				return (TBL_DATA) MetaDefault.GetEntity(entityName);
			}
			public static TBL_DATA NewEntity()
			{
				return (TBL_DATA) MetaDefault.NewEntity();
			}
		}

#pragma warning restore 414
