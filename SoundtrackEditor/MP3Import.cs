﻿// Sourced from here: http://answers.unity3d.com/questions/380838/is-there-any-converter-mp3-to-ogg-.html
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Text;

public class MP3Import
{
    public IntPtr handle_mpg;
    public IntPtr errPtr;
    public IntPtr rate;
    public IntPtr channels;
    public IntPtr encoding;
    public IntPtr id3v1;
    public IntPtr id3v2;
    public IntPtr done;

    public string mPath;
    public int x;
    public int intRate;
    public int intChannels;
    public int intEncoding;
    public int FrameSize;
    public int lengthSamples;
    public AudioClip myClip;
    public AudioSource audioSource;

    #region Consts: Standard values used in almost all conversions.
    private const float const_1_div_128_ = 1.0f / 128.0f;  // 8 bit multiplier
    private const float const_1_div_32768_ = 1.0f / 32768.0f; // 16 bit multiplier
    private const double const_1_div_2147483648_ = 1.0 / 2147483648.0; // 32 bit
    #endregion

    public AudioClip StartImport(string mPath)
    {
        MPGImport.mpg123_init();
        handle_mpg = MPGImport.mpg123_new(null, errPtr);
        x = MPGImport.mpg123_open(handle_mpg, mPath);
        MPGImport.mpg123_getformat(handle_mpg, out rate, out channels, out encoding);
        intRate = rate.ToInt32();
        intChannels = channels.ToInt32();
        intEncoding = encoding.ToInt32();

        MPGImport.mpg123_id3(handle_mpg, out id3v1, out id3v2);
        MPGImport.mpg123_format_none(handle_mpg);
        MPGImport.mpg123_format(handle_mpg, intRate, intChannels, 208);

		Debug.Log("Getting ID3 info");
		MPGImport.mpg123_id3v1 v1 = (MPGImport.mpg123_id3v1)Marshal.PtrToStructure(id3v1, typeof(MPGImport.mpg123_id3v1));
		//MPGImport.mpg123_id3v2 v2 = (MPGImport.mpg123_id3v2)Marshal.PtrToStructure(id3v2, typeof(MPGImport.mpg123_id3v2));
		Debug.Log(new String(v1.album));	// "Runnin' Wild"
		Debug.Log(new String(v1.artist));	// "Airbourne"
		Debug.Log(new String(v1.title));	// "Stand Up For Rock N Roll"
		Debug.Log(new String(v1.year));		// "2007"
		Debug.Log(v1.genre);				// 17
		Debug.Log(new String(v1.comment));	// "Ripped By Kotton"
		Debug.Log(new String(v1.tag));		// "TAG"


        FrameSize = MPGImport.mpg123_outblock(handle_mpg);
        byte[] Buffer = new byte[FrameSize];
        lengthSamples = MPGImport.mpg123_length(handle_mpg);

        myClip = AudioClip.Create(new String(v1.title), lengthSamples, intChannels, intRate, false, false);

        int importIndex = 0;

        while (0 == MPGImport.mpg123_read(handle_mpg, Buffer, FrameSize, out done))
        {
            float[] fArray;
            fArray = ByteToFloat(Buffer);

            myClip.SetData(fArray, (importIndex * fArray.Length) / 2);

            importIndex++;
        }

        MPGImport.mpg123_close(handle_mpg);
        return myClip;
    }

    public float[] IntToFloat(Int16[] from)
    {
        float[] to = new float[from.Length];

        for (int i = 0; i < from.Length; i++)
            to[i] = (float)(from[i] * const_1_div_32768_);

        return to;
    }

    public Int16[] ByteToInt16(byte[] buffer)
    {
        Int16[] result = new Int16[1];
        int size = buffer.Length;
        if ((size % 2) != 0)
        {
            /* Error here */
            Console.WriteLine("error");
            return result;
        }
        else
        {
            result = new Int16[size / 2];
            IntPtr ptr_src = Marshal.AllocHGlobal(size);
            Marshal.Copy(buffer, 0, ptr_src, size);
            Marshal.Copy(ptr_src, result, 0, result.Length);
            Marshal.FreeHGlobal(ptr_src);
            return result;
        }
    }

    public float[] ByteToFloat(byte[] bArray)
    {
        Int16[] iArray;

        iArray = ByteToInt16(bArray);

        return IntToFloat(iArray);
    }
}
