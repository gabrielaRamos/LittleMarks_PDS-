using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class QRCode : MonoBehaviour {

	public RawImage rt;
	public Button button_1, button_2, button_3, button_4;
	public Image image_1, image_2, image_3, image_4;
	public Text text_1, text_2, text_3, text_4;

	public int pizzaPrice = 12;
	public int burguerPrice = 12;
	public int friesPrice = 12;
	public int colaPrice = 12;

	public void generateQR(string text) {


		var encoded = new Texture2D (256, 256);
		var color32 = Encode(text, encoded.width, encoded.height);
		encoded.SetPixels32(color32);
		encoded.Apply();

		if (text.CompareTo("refrigeranteneri") == 0 && PrizeUpdater.instance.colaCount >= colaPrice) {
			PrizeUpdater.instance.colaCount = PrizeUpdater.instance.colaCount - colaPrice;
			enableButtons (encoded);
		}
		else if (text.CompareTo ("batataneri") == 0 && PrizeUpdater.instance.friesCount >= friesPrice) {
			PrizeUpdater.instance.friesCount = PrizeUpdater.instance.friesCount - friesPrice;
			enableButtons (encoded);
		}
		else if (text.CompareTo ("refribatneri") == 0 && PrizeUpdater.instance.burguerCount >= burguerPrice) {
			PrizeUpdater.instance.burguerCount = PrizeUpdater.instance.burguerCount - burguerPrice;
			enableButtons (encoded);
		}
		else if (text.CompareTo ("pizzaneri") == 0 && PrizeUpdater.instance.pizzaCount >= pizzaPrice) {
			PrizeUpdater.instance.pizzaCount = PrizeUpdater.instance.pizzaCount - pizzaPrice;
			enableButtons (encoded);
		}
	
		PrizeUpdater.instance.setText();

	}

	private static Color32[] Encode(string textForEncoding, 
		int width, int height) {
		var writer = new BarcodeWriter {
			Format = BarcodeFormat.QR_CODE,
			Options = new QrCodeEncodingOptions {	
				Height = height,
				Width = width
			}
		};
		return writer.Write(textForEncoding);
	}

	private void enableButtons(Texture2D encoded){

		rt.texture = encoded;
		rt.enabled = !rt.enabled;

		button_1.image.enabled = !button_1.image.enabled;
		button_2.image.enabled = !button_2.image.enabled;
		button_3.image.enabled = !button_3.image.enabled;
		button_4.image.enabled = !button_4.image.enabled;

		image_1.enabled = !image_1.enabled;
		image_2.enabled = !image_2.enabled;
		image_3.enabled = !image_3.enabled;
		image_4.enabled = !image_4.enabled;

		text_1.enabled = !text_1.enabled;
		text_2.enabled = !text_2.enabled;
		text_3.enabled = !text_3.enabled;
		text_4.enabled = !text_4.enabled;
	}

}

