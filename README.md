# tukineko_csharp
[WIP] Tukineko csharp port with Winform, by pixel or node based drawing system, for being ported to Godot Mono

## History  
* 2025-02-23, tukineko_ctrl (node-based) csharp v13 final before open source  
* 2025-02-19, tukineko_ctrl (node-based) csharp v1  
* 2025-02-02, tukineko (pixel-based) csharp v9  
* 2025-01-23, tukineko (pixel-based) csharp v1  

## Test Data  
* Need to copy data files to the MOON folder from 月姫 (Tsukihime) or 月箱  
* https://gitee.com/weimingtom2000/nscripter_java  

## References    
* http://www.din.or.jp/~boya/tsukihime/tukineko/index.html  
* http://www.din.or.jp/~boya/  
* https://gitee.com/weimingtom2000/nscripter_java    

## Patches
* https://github.com/weimingtom/tukineko_csharp/tree/master/tukineko  
background picture fixed  
but main menu button picture not fixed   
see https://github.com/weimingtom/tukineko_csharp/blob/master/tukineko/java/awt/Graphics_.cs    
_graph.DrawImage(i._bufferBmp, x, y, 320, 240);    
```
		public void drawImage(Image_ i, int x, int y, Panel_ p)
		{
			if (_graph != null)
			{
				if (x == 0 && y == 0)
				{
					_graph.DrawImage(i._bufferBmp, x, y, 320, 240);
				}
				else
				{
					_graph.DrawImage(i._bufferBmp, x, y, i._bufferBmp.Width, i._bufferBmp.Height);
				}
			}
		}
```
