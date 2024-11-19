using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturePool : MonoBehaviour
{
    public TextureFormat tex_format;
    public Texture2D [] texs;
    public Texture2D ErrorTexture;
    public int [] texs_id;
    private int [] dirty;
    int max_texs = 64, texs_loaded = 0;
    // Start is called before the first frame update
    void Start()
    {
        tex_format = TextureFormat.RGBA32;
        texs = new Texture2D[max_texs];
        texs_id = new int[max_texs];
        dirty = new int[max_texs];
        for(int i=0;i<max_texs;i++){
            texs_id[i] = -1;
            dirty[i] = -1;
            texs[i] = new Texture2D(64,64, tex_format, false);
        }
    }
    public int FindNext(){
        return -1;

    }
    public int IdReserved(int _id){
        return -1;

    }
    public int LoadTex(string fn){
        return -1;
    }
    public void CreateErrorTexture(){
        ErrorTexture = new Texture2D(64,64, tex_format, false);

    }
    public void AddTex(Texture2D tex, int texid, Vector4 rect, bool fullscreen){

    }
    public Texture2D FindById(int _id){
        for(int i=0;i<max_texs;i++){
            if(dirty[i]>0 && texs_id[i] == _id){
                return texs[i];
            }
        }
        return ErrorTexture;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
