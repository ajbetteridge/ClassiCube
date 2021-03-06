﻿// Copyright 2014-2017 ClassicalSharp | Licensed under BSD-3
using System;
using OpenTK;
using BlockID = System.UInt16;

namespace ClassicalSharp.Blocks {
	
	/// <summary> Stores default properties for blocks in Minecraft Classic. </summary>
	public static class DefaultSet {
		
		public static float Height(BlockID b) {
			if (b == Block.Slab) return 8/16f;
			if (b == Block.CobblestoneSlab) return 8/16f;
			if (b == Block.Snow) return 2/16f;
			return 1;
		}
		
		public static bool FullBright(BlockID b) {
			return b == Block.Lava || b == Block.StillLava
				|| b == Block.Magma || b == Block.Fire;
		}
		
		public static float FogDensity(BlockID b) {
			if (b == Block.Water || b == Block.StillWater)
				return 0.1f;
			if (b == Block.Lava || b == Block.StillLava)
				return 1.8f;
			return 0;
		}
		
		public static PackedCol FogColour(BlockID b) {
			if (b == Block.Water || b == Block.StillWater)
				return new PackedCol(5, 5, 51);
			if (b == Block.Lava || b == Block.StillLava)
				return new PackedCol(153, 25, 0);
			return default(PackedCol);
		}
		
		public static byte Collide(BlockID b) {
			if (b == Block.Ice) return CollideType.Ice;
			if (b == Block.Water || b == Block.StillWater)
				return CollideType.LiquidWater;
			if (b == Block.Lava || b == Block.StillLava)
				return CollideType.LiquidLava;
			
			if (b == Block.Snow || b == Block.Air || Draw(b) == DrawType.Sprite)
				return CollideType.Gas;
			return CollideType.Solid;
		}
		
		public static byte MapOldCollide(BlockID b, byte collide) {
			if (b == Block.Rope && collide == CollideType.Gas)
				return CollideType.ClimbRope;
			if (b == Block.Ice && collide == CollideType.Solid) 
				return CollideType.Ice;
			if ((b == Block.Water || b == Block.StillWater) && collide == CollideType.Liquid)
				return CollideType.LiquidWater;
			if ((b == Block.Lava || b == Block.StillLava) && collide == CollideType.Liquid)
				return CollideType.LiquidLava;
			return collide;
		}
		
		public static bool BlocksLight(BlockID b) {
			return !(b == Block.Glass || b == Block.Leaves 
			         || b == Block.Air || Draw(b) == DrawType.Sprite);
		}

		public static byte StepSound(BlockID b) {
			if (b == Block.Glass) return SoundType.Stone;
			if (b == Block.Rope) return SoundType.Cloth;
			if (Draw(b) == DrawType.Sprite) return SoundType.None;
			return DigSound(b);
		}
		
		
		public static byte Draw(BlockID b) {
			if (b == Block.Air) return DrawType.Gas;
			if (b == Block.Leaves) return DrawType.TransparentThick;

			if (b == Block.Ice || b == Block.Water || b == Block.StillWater) 
				return DrawType.Translucent;
			if (b == Block.Glass || b == Block.Leaves)
				return DrawType.Transparent;
			
			if (b >= Block.Dandelion && b <= Block.RedMushroom)
				return DrawType.Sprite;
			if (b == Block.Sapling || b == Block.Rope || b == Block.Fire)
				return DrawType.Sprite;
			return DrawType.Opaque;
		}		

		public static byte DigSound(BlockID b) {
			if (b >= Block.Red && b <= Block.White) 
				return SoundType.Cloth;
			if (b >= Block.LightPink && b <= Block.Turquoise) 
				return SoundType.Cloth;
			if (b == Block.Iron || b == Block.Gold)
				return SoundType.Metal;
			
			if (b == Block.Bookshelf || b == Block.Wood 
			   || b == Block.Log || b == Block.Crate || b == Block.Fire)
				return SoundType.Wood;
			
			if (b == Block.Rope) return SoundType.Cloth;
			if (b == Block.Sand) return SoundType.Sand;
			if (b == Block.Snow) return SoundType.Snow;
			if (b == Block.Glass) return SoundType.Glass;
			if (b == Block.Dirt || b == Block.Gravel)
				return SoundType.Gravel;
			
			if (b == Block.Grass || b == Block.Sapling || b == Block.TNT
			   || b == Block.Leaves || b == Block.Sponge)
				return SoundType.Grass;
			
			if (b >= Block.Dandelion && b <= Block.RedMushroom)
				return SoundType.Grass;
			if (b >= Block.Water && b <= Block.StillLava)
				return SoundType.None;
			if (b >= Block.Stone && b <= Block.StoneBrick)
				return SoundType.Stone;
			return SoundType.None;
		}
	}
}