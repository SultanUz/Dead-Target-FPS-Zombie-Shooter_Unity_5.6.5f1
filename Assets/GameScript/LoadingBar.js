var originalWidth = 640.0; 
var originalHeight = 1136.0;
private var scale: Vector3;
var progressBar : Texture2D;
private var async : AsyncOperation;
//var LevelToLoad : int;
private var progress : float;


function OnGUI()
{
    scale.x = Screen.width/originalWidth; 
    scale.y = Screen.height/originalHeight; 
    scale.z = 1;
    var svMat = GUI.matrix; 
    GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
    if(async)
    {
         progress = async.progress;        
         GUI.DrawTexture(Rect(75,1000, 600 * Mathf.Clamp01(progress), 50), progressBar);
    }
//    if(GUI.Button(Rect(50,474,100,50),"Stage1"))
//    {
//          async = Application.LoadLevelAsync("Round 1");   
//    }
}
function Levels (LevelToLoad:int )
{
	async = Application.LoadLevelAsync("Round " + LevelToLoad);
	
}