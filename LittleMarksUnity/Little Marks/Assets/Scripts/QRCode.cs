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

	public void generateQR(string text) {
		var encoded = new Texture2D (256, 256);
		var color32 = Encode(text, encoded.width, encoded.height);
		encoded.SetPixels32(color32);
		encoded.Apply();

		rt.texture = encoded;
		rt.enabled = !rt.enabled;
		button_1.image.enabled = !button_1.image.enabled;
		button_2.image.enabled = !button_2.image.enabled;
		button_3.image.enabled = !button_3.image.enabled;
		button_4.image.enabled = !button_4.image.enabled;

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

}

