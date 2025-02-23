using System;

namespace tukineko
{
	public class Util {
		/*
		 * private int evalNumAlias(String paramString) { if
		 * (this.nd.numalias.containsKey(paramString) == true) { return
		 * int.parseInt(this.nd.numalias.get(paramString)); } return
		 * int.parseInt(paramString); }
		 * 
		 * private int evalNum(String paramString) { if
		 * (paramString.StartsWith("%")) { return
		 * this.nd.valueNum[evalNumAlias(paramString.substring(1))]; } return
		 * evalNumAlias(paramString); }
		 * 
		 * private String evalStrAlias(String paramString) { if
		 * (this.nd.stralias.containsKey(paramString) == true) { return
		 * this.nd.stralias.get(paramString); } return paramString; }
		 * 
		 * public String evalStr(String paramString) { if
		 * (paramString.StartsWith("$") == true) { return
		 * this.nd.valueStr[evalNum(paramString.substring(1))]; } return
		 * evalStrAlias(paramString); }
		 * 
		 * private bool evalBoolean(String paramString) { return
		 * evalNum(paramString) == 1; }
		 * 
		 * private NsColor evalColor(String paramString) { if ((paramString.length()
		 * != 7) || (!paramString.StartsWith("#"))) { error("color value: " +
		 * paramString); return null; } try { return new NsColor(
		 * int.parseInt(paramString.substring(1), 16) | 0xFF000000); } catch
		 * (NumberFormatException e) { error("color value: " + paramString); }
		 * return null; }
		 */

		/*
		 * private void wait(int paramInt, bool paramBoolean) { if
		 * (!paramBoolean) { try { Thread.sleep(paramInt); } catch (Exception
		 * localException1) { } } else { this.nd.click = false; if (paramInt == 0) {
		 * do { try { Thread.sleep(100L); } catch (Exception localException2) { } if
		 * (this.nd.click) { break; } } while (this.nd.storageState == 0); } else {
		 * int i = paramInt; while ((this.nd.click != true) && (this.nd.storageState
		 * == 0)) { if (i > 100) { try { Thread.sleep(100L); } catch (Exception
		 * localException3) { } i -= 100; continue; } try { Thread.sleep(i); } catch
		 * (Exception localException4) { } } } } }
		 */	
	}
}
