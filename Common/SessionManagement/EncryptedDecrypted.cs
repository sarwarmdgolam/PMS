using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Authentication
{
    [Serializable]
    public class EncryptedDecrypted
    {
        private string pwdForHashString = "bblEplSecretpassword";
        public EncryptedDecrypted()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string GetEncrypted(string strOriginal)
        {
            string strEncrypted;
            TripleDESCryptoServiceProvider des;
            MD5CryptoServiceProvider hashmd5;
            byte[] pwdhash, buff;

            ////create a string to encrypt
            //original = "hi, my name is bill but you wouldn't know me";

            //generate an MD5 hash from the pstrPassword. 
            //a hash is a one way encryption meaning once you generate
            //the hash, you cant derive the pstrPassword back from it.
            hashmd5 = new MD5CryptoServiceProvider();
            pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(this.pwdForHashString));
            hashmd5 = null;

            //implement DES3 encryption
            des = new TripleDESCryptoServiceProvider();

            //the key is the secret pstrPassword hash.
            des.Key = pwdhash;

            //the mode is the block cipher mode which is basically the
            //details of how the encryption will work. There are several
            //kinds of ciphers available in DES3 and they all have benefits
            //and drawbacks. Here the Electronic Codebook cipher is used
            //which means that a given bit of text is always encrypted
            //exactly the same when the same pstrPassword is used.
            des.Mode = CipherMode.ECB; //CBC, CFB


            //----- encrypt an un-encrypted string ------------
            //the original string, which needs encrypted, must be in byte
            //array form to work with the des3 class. everything will because
            //most encryption works at the byte level so you'll find that
            //the class takes in byte arrays and returns byte arrays and
            //you'll be converting those arrays to strings.
            buff = ASCIIEncoding.ASCII.GetBytes(strOriginal);

            //encrypt the byte buffer representation of the original string
            //and base64 encode the encrypted string. the reason the encrypted
            //bytes are being base64 encoded as a string is the encryption will
            //have created some weird characters in there. Base64 encoding
            //provides a platform independent view of the encrypted string 
            //and can be sent as a plain text string to wherever.
            strEncrypted = Convert.ToBase64String(
                des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length)
            );


            //----- decrypt an encrypted string ------------
            //whenever you decrypt a string, you must do everything you
            //did to encrypt the string, but in reverse order. To encrypt,
            //first a normal string was des3 encrypted into a byte array
            //and then base64 encoded for reliable transmission. So, to 
            //decrypt this string, first the base64 encoded string must be 
            //decoded so that just the encrypted byte array remains.
            //buff = Convert.FromBase64String(encrypted);

            ////decrypt DES 3 encrypted byte buffer and return ASCII string
            //decrypted = ASCIIEncoding.ASCII.GetString(
            //    des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length)
            //);


            //cleanup
            des = null;

            return strEncrypted;
        }

        public string GetDecrypted(string strEncrypted)
        {
            string strDecrypted;
            TripleDESCryptoServiceProvider des;
            MD5CryptoServiceProvider hashmd5;
            byte[] pwdhash, buff;

            ////create a string to encrypt
            //original = "hi, my name is bill but you wouldn't know me";

            ////generate an MD5 hash from the pstrPassword. 
            ////a hash is a one way encryption meaning once you generate
            ////the hash, you cant derive the pstrPassword back from it.
            hashmd5 = new MD5CryptoServiceProvider();
            pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(this.pwdForHashString));
            hashmd5 = null;

            ////implement DES3 encryption
            des = new TripleDESCryptoServiceProvider();

            ////the key is the secret pstrPassword hash.
            des.Key = pwdhash;

            ////the mode is the block cipher mode which is basically the
            ////details of how the encryption will work. There are several
            ////kinds of ciphers available in DES3 and they all have benefits
            ////and drawbacks. Here the Electronic Codebook cipher is used
            ////which means that a given bit of text is always encrypted
            ////exactly the same when the same pstrPassword is used.
            des.Mode = CipherMode.ECB; //CBC, CFB


            ////----- encrypt an un-encrypted string ------------
            ////the original string, which needs encrypted, must be in byte
            ////array form to work with the des3 class. everything will because
            ////most encryption works at the byte level so you'll find that
            ////the class takes in byte arrays and returns byte arrays and
            ////you'll be converting those arrays to strings.
            //buff = ASCIIEncoding.ASCII.GetBytes(original);

            ////encrypt the byte buffer representation of the original string
            ////and base64 encode the encrypted string. the reason the encrypted
            ////bytes are being base64 encoded as a string is the encryption will
            ////have created some weird characters in there. Base64 encoding
            ////provides a platform independent view of the encrypted string 
            ////and can be sent as a plain text string to wherever.
            //encrypted = Convert.ToBase64String(
            //    des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length)
            //);


            //----- decrypt an encrypted string ------------
            //whenever you decrypt a string, you must do everything you
            //did to encrypt the string, but in reverse order. To encrypt,
            //first a normal string was des3 encrypted into a byte array
            //and then base64 encoded for reliable transmission. So, to 
            //decrypt this string, first the base64 encoded string must be 
            //decoded so that just the encrypted byte array remains.
            buff = Convert.FromBase64String(strEncrypted);

            //decrypt DES 3 encrypted byte buffer and return ASCII string
            strDecrypted = ASCIIEncoding.ASCII.GetString(
                des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length)
            );


            //cleanup
            des = null;

            return strDecrypted;
        }

        public string GetRandomPassword()
        {

            string allowedChars = "";
            allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";

            char[] sep ={ ',' };
            string[] arr = allowedChars.Split(sep);

            string passwordString = "";

            string temp = "";

            Random rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                passwordString += temp;
            }

            return passwordString;
        }

    }
}
