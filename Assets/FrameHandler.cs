using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameHandler : MonoBehaviour
{
	public int tex_id, tex_x, tex_y,tex_w,tex_h;
	public TexturePool texpool;
	public int textureWidth;    // Width of the texture
   	public int textureHeight;   // Height of the texture
    public int screenWidth, screenHeight, fakeWidth, fakeHeight, ratio_w, ratio_h;
   	public int randomPixelCount = 80000; // Number of random white pixels
	public StarSystemHandler star_system;
    public LevelHandler level;
   	public Texture2D texture;
   	public RawImage rawImage;
   	int [,] dirty;
   	int [,] circle_start_length;
   	int circle_radius, circle_area, circle_circle;
   	int view_mode = 0;
   	public bool tex_ok;
    public  TextureFormat tex_format;   	
   	void ShipRadar() {
   		
   	}
   	
   	void Awake(){
   		tex_ok = false;
   		textureWidth = 4096;
   		textureHeight = 4096;
   		//texpool = GameObject.Find("TexturePool").GetComponent<TexturePool>();
   }
   	void Start(){
   	    tex_format = TextureFormat.RGBA32;
        Init();
    }
        
    void Init()
    {
        	
    	//var gfx_format = GR8G8B8A8_UINT;
    	bool fresh_tex = true, map_generated = true;
      
     //   if(texpool.IdReserved(tex_id)>=0) {
        	//texture = texpool.FindById(tex_id);
        	/*if(texture.format == tex_format){
        		fresh_tex = false;
        		textureWidth=texture.width;
        		textureHeight=texture.height;
        		map_generated=true;
            } else {
        	// make a map
            	textureWidth=4096;
            	textureHeight=4096;
            //tex_id = texpool.AddTex(n);
        	//texture = texpool.FindById(tex_id);
        	    map_generated = false;
        */
        //Texture2D new_tex = new Texture2D(textureWidth, textureHeight, TextureFormat.RGBA32, false);
        		
        dirty = new int[textureHeight, textureWidth];
        
        // Step 2: Black out every pixel by setting it to Color.black
        Color32 black = new Color32(0, 0, 0, 255);
        for (int x = 0; x < textureWidth; x++)
        {
            for (int y = 0; y < textureHeight; y++)
            {
                texture.SetPixel(x, y, black);
                dirty[y, x] = 0;
          ///      new_tex.SetPixel(x,y,black);
            }
        }
        
        // Apply initial black texture
        texture.Apply();
        //new_tex.Apply();
        // Step 3: Set some random pixels to white
        Color32 white = new Color32(255, 255, 255, 255);
        for (int i = 0; i < randomPixelCount; i++)
        {        	
            int randomX = Random.Range(1, textureWidth);
            int randomY = Random.Range(1, textureHeight);

	       	dirty[randomY, randomX]=1;
            texture.SetPixel(randomX, randomY, white);    
        }
        float dist_treshold = 5.0f;
        int cw = 100;
        int ch = 100;
        for(int x = 0; x < textureWidth;x++){
        	for(int y = 0; y < textureHeight;y++){
        		for(int cx=cw/2;cx<(cw/2);cx++){
        			for(int cy=ch/2;cy<(ch/2);cy++){
        				float a=(float)x,b=(float)y,c=(float) cx,d =(float) cy;
        				float xx = (a+c);float yy = (b+d); float dist = Mathf.Sqrt(xx*yy);
        				if(dist >= dist_treshold){
	        				if(x<0 || y < 0 || xx < 0 || yy < 0 || xx >= 4095|| yy <= 4095) {
	        					 
        					}
        				}
        			}
        		}
        	}
        }
//        texture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGBA32, false);
        // Apply changes to the texture
            texture.Apply();

        // Step 4: Attach the texture to the RawImage component
            rawImage = GetComponent<RawImage>();
            if (rawImage != null)
            {
                rawImage.texture = texture;
            }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
