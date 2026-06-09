# tukineko_csharp
[WIP] Tukineko csharp port with Winform, by pixel or node based drawing system, for being ported to Godot Mono

## History  
* 2025-02-23, tukineko_ctrl (node-based) csharp v13 final before open source  
* 2025-02-19, tukineko_ctrl (node-based) csharp v1  
* 2025-02-02, tukineko (pixel-based) csharp v9  
* 2025-01-23, tukineko (pixel-based) csharp v1  

## Test Data  
* Please BUY the Game
* Need to copy data files to the MOON folder from 月姫 (Tsukihime) or 月箱  
* (x) https://gitee.com/weimingtom2000/nscripter_java  
* (Please BUY the Game) Or from 同人ゲーム詰め合わせ, (同人ゲーム) 月姫.rar   
https://archive.org/details/doujin-game-tsumeawase   
but You need complex operations to obtain the game files from these files, so you had better buy the game.    

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
* https://github.com/weimingtom/tukineko_csharp/tree/master/tukineko_ctrl  
menu button picture fixed  
but not sync to tukineko  
https://github.com/weimingtom/tukineko_csharp/blob/master/tukineko/tukineko/NsWindow.cs  
TODO: not fixed  
```
			if ((this.ndata.btnVisible == true) && (this.ndata.btnSel != -1)) {
				NsButton localNsButton = this.ndata.btn[this.ndata.btnSel];
				this.frmBuffBG.setClip(localNsButton.x >> 1, localNsButton.y >> 1,
						localNsButton.width >> 1, localNsButton.height >> 1);
				if ((localImage = NsImageCache.get(this.ndata.btnImage)) != null) {
					
					if (false)
					{
						//bug: if click, menu button shows larger 
						this.frmBuffBG.drawImage(localImage, (localNsButton.x >> 1)
							- (localNsButton.u >> 1), (localNsButton.y >> 1)
							- (localNsButton.v >> 1), this);
					}
					else
					{
						//FIXME:need temp Bitmap cloneImage
						System.Drawing.Bitmap cloneImage = new System.Drawing.Bitmap(localNsButton.width, localNsButton.height);
						if (localImage._bufferBmp is System.Drawing.Bitmap)
						{
							System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(cloneImage);
							graphics.DrawImage(localImage._bufferBmp,
							    -localNsButton.u, //(localNsButton.x) - (localNsButton.u), 
							    -localNsButton.v, //(localNsButton.y) - (localNsButton.v),
							    localImage._bufferBmp.Width, 
							    localImage._bufferBmp.Height);
						}
						Image_ cloneImg = new Image_();
						cloneImg._bufferBmp = cloneImage;
						//this.frmBuffBG.drawImage(cloneImg, localNsButton.x >> 1, localNsButton.y >> 1, this);
						//this.frmBuffBG._graph.DrawImage(cloneImage, localNsButton.x >> 1, localNsButton.y >> 1, cloneImage.Width, cloneImage.Height);
						this.frmBuffBG._graph.DrawImage(cloneImage, localNsButton.x >> 1, localNsButton.y >> 1, localNsButton.width >> 1, localNsButton.height >> 1);
					}
					
				}
				this.frmBuffBG.setClip(0, 0, 320, 240);
			}
```
see also tukineko_ctrl sources:
```
search: ns.nd.btnSel = k;

				ns.nd.btnVisible = true;
				ns.nd.click = false;
				int k = -1;
				NsButton localNsButton;
				while (ns.storageState == 0) {
					if (ns.nd.click == true) {
						ns.nd.click = false;
						k = -1;
						for (int j = 0; j < ns.nd.btn.Count; j++) {
							localNsButton = ns.nd.btn[j];
							if ((localNsButton.x > ns.nd.clickX) || 
								(ns.nd.clickX >= localNsButton.x + localNsButton.width) || 
								(localNsButton.y > ns.nd.clickY) || 
								(ns.nd.clickY >= localNsButton.y + localNsButton.height)) {
								continue;
							}
							k = j;
							break;
						}
						if (ns.nd.btnSel != k) {
							ns.nd.btnSel = k;
						} else {
							if (ns.nd.btnSel >= 0) {
								break;
							}
						}
						ns.tn.paintB();
					}
					try {
						Thread.Sleep(100);
					} catch (Exception) {

					}
				}
				
				

-----------------------------
search: NsButton localNsButton = this.ndata.btn[this.ndata.btnSel];

			//FIXME:added
			MainForm.getInstance().picturebox_button.Visible = false;
			//TODO:not implemented
			if ((this.ndata.btnVisible == true) && (this.ndata.btnSel != -1)) {
				NsButton localNsButton = this.ndata.btn[this.ndata.btnSel];
//				this.frmBuffBG.setClip(localNsButton.x >> 1, localNsButton.y >> 1,
//						localNsButton.width >> 1, localNsButton.height >> 1);
				if ((localImage = NsImageCache.get(this.ndata.btnImage)) != null) {
//					this.frmBuffBG.drawImage(localImage, (localNsButton.x >> 1)
//							- (localNsButton.u >> 1), (localNsButton.y >> 1)
//							- (localNsButton.v >> 1), this);
					MainForm.getInstance().picturebox_button.Location = new Point(localNsButton.x >> 1, localNsButton.y >> 1);
					MainForm.getInstance().picturebox_button.Size = new Size(localNsButton.width >> 1, localNsButton.height >> 1);
					Bitmap cloneImage = new Bitmap(localNsButton.width, localNsButton.height);
					if (localImage._bufferBmp is Bitmap)
					{
						Graphics graphics = Graphics.FromImage(cloneImage);
						graphics.DrawImage(localImage._bufferBmp,
						    -localNsButton.u, //(localNsButton.x) - (localNsButton.u), 
						    -localNsButton.v, //(localNsButton.y) - (localNsButton.v),
						    localImage._bufferBmp.Width, 
						    localImage._bufferBmp.Height);
					}
					MainForm.getInstance().picturebox_button.Image = cloneImage;//localImage._bufferBmp;
					MainForm.getInstance().picturebox_button.Visible = true;
//					MainForm.getInstance().picturebox_button.Padding = new Padding(1, 1, 0, 0);
//						(localNsButton.x >> 1) - (localNsButton.u >> 1), 
//						(localNsButton.y >> 1) - (localNsButton.v >> 1), 0, 0);
				}
//				this.frmBuffBG.setClip(0, 0, 320, 240);
			}			
			
			
```
