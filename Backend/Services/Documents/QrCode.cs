using System;
using QRCoder;

namespace Backend.Services.Documents
{
    public class QrCode
    {
        public byte[] CreateQrCode(int id)
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData qRCodeData = generator.CreateQrCode($"http://54.174.164.124:3000/",QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrcode = new BitmapByteQRCode(qRCodeData);
            byte[] qrCodeAsBitmapByteArr = qrcode.GetGraphic(20);
            return qrCodeAsBitmapByteArr;
        }
    }
}