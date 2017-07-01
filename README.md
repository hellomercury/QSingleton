# QSingleton
Graceful Unity3D C# singleton implement toolkit.

It make everything to singleton gracefully!

#### Feature:

- C#/MonoBehaviour Class Singleton Implement Tool
- Get property method to implement singleton

#### Quick Start:

```c#
namespace QFramework.Example
{
	[QMonoSingletonPath("[Audio]/AudioManager")]
	public class AudioManager : ManagerBase,ISingleton
	{
		public static AudioManager Instance
		{
			get { return QMonoSingletonProperty<AudioManager>.Instance; }
		}
		
		public void OnSingletonInit()
		{
			
		}

		public void Dispose()
		{
			QMonoSingletonProperty<AudioManager>.Dispose();
		}


		public void PlaySound(string soundName)
		{
			
		}

		public void StopSound(string soundName)
		{
			
		}
	}
}
```

You will see result:

![](http://liangxiegame.com/content/images/2017/07/-----2017-07-01-12-52-29.png)

#### Contact:

* liangxiegame@163.com ,if you have any idea or discussion about QSingleton,mail me now!

#### Support Projects:

* [QFramework](https://github.com/liangxiegame/QFramework)