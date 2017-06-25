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

namespace QFramework.Example
{
	using System.Collections;
	using UnityEngine;
	
	class Class2MonoSingletonProperty : MonoBehaviour,ISingleton
	{
		public static Class2MonoSingletonProperty Instance
		{
			get { return QMonoSingletonProperty<Class2MonoSingletonProperty>.Instance; }
		}
		
		public void Dispose()
		{
			QMonoSingletonProperty<Class2MonoSingletonProperty>.Dispose();
		}
		
		public void OnSingletonInit()
		{
			Debug.Log(this.name + ":" + "OnSingletonInit");
		}



		private void Awake()
		{
			Debug.Log(this.name + ":" + "Awake");
		}

		private void Start()
		{
			Debug.Log(this.name + ":" + "Start");
		}

		protected void OnDestroy()
		{
			Debug.Log(this.name + ":" + "OnDestroy");
		}
	}

	public class MonoSingletonProperty : MonoBehaviour
	{
		private IEnumerator Start()
		{
			var instance = Class2MonoSingletonProperty.Instance;

			yield return new WaitForSeconds(3.0f);
			
			instance.Dispose();
		}
	}
}