using UnityEngine;
using UnityEngine.EventSystems;

public delegate void OnClickDelegate(CreatureSetting character);
class MemberSelectButton : BackgroundButton
{
	private CreatureSetting character;
	public void setCharacter(CreatureSetting _character)
	{
		character = _character;
		tmp.text = character.displayName;
	}

	public override void OnSelect(BaseEventData e)
	{
		base.OnSelect(e);
		if(onClickDelegate != null) // FIXME: 大丈夫か？
		{
			onClickDelegate(character);
		}
	}

	public OnClickDelegate onClickDelegate;

	public void onClick(OnClickDelegate _delegate)
	{
		onClickDelegate = _delegate;
	}
}