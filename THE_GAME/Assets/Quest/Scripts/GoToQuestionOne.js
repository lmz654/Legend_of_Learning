#pragma strict

function OnTriggerEnter (hit: Collider)
{
    
    Application.LoadLevel ("Quest1");
    Cursor.visible = true;
}