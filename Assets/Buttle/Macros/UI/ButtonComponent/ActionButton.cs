class ActionButton : BaseButton
{

	public Action.Types type;

	public void setType(Action.Types _type){
		type = _type;
	}

	public Action.Types getType(){
		return type;
	}
}