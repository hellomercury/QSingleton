﻿/****************************************************************************
 * Copyright (c) 2017 liangxie
 * 
 * http://liangxiegame.com
 * https://github.com/liangxiegame/QSingleton
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
****************************************************************************/

using UnityEngine;

namespace QFramework.Test
{
	using NUnit.Framework;
	using QFramework;
	
	public class QSingletonTest
	{
		class SingletonTest : QSingleton<SingletonTest>
		{
			public static int InstanceCount = 0;

			private SingletonTest()
			{
			}

			public override void OnSingletonInit()
			{
				base.OnSingletonInit();
				InstanceCount++;
			}

			public override void Dispose()
			{
				base.Dispose();
				InstanceCount--;
			}
		}
		
		[Test]
		public void TestQSingleton()
		{
			var instance = SingletonTest.Instance;

			instance = SingletonTest.Instance;
			
			Assert.AreEqual(1,SingletonTest.InstanceCount);
			
			instance.Dispose();
			
			Assert.AreEqual(0,SingletonTest.InstanceCount);
		}

		
		[QMonoSingletonPath("[Mono]/MonoSingleton")]
		class MonoSingletonTest : QMonoSingleton<MonoSingletonTest>
		{
			public static int InstanceCount = 0;

			private MonoSingletonTest()
			{
				InstanceCount++;
			}


			public override void Dispose()
			{
				base.Dispose();
				InstanceCount--;
			}
		}

		[Test]
		public void TestQMonoSingleton()
		{
			Assert.IsTrue(MonoSingletonTest.Instance == null);
			// Application.isPlaying can't used in editor test mode
//			Assert.IsTrue(string.Equals(MonoSingletonTest.Instance.name,"MonoSingleton"));
//			Assert.IsTrue(string.Equals(MonoSingletonTest.Instance.transform.parent,"[Mono]"));
		}
	}
}