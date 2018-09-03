﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyGUI;
using THClimbTower;

namespace Model
{
    [GameUIView(UIViewType.ChooseCharactor)]
    public class ChooseCharactorView:GameUIView
    {
        public override string PackageName { get; set; } = "THClimbTower";

        public override string ViewName { get; set; } = "ChooseCharactor";

        CharactorTypeEnum mainType, helpType;

        public override void Creat()
        {
            MainView.GetChild("StartGame").onClick.Add(() =>
            {
                Game.Scene.GetComponent<UIManagerComponent>().LoadSence(UIViewType.Map);
                THClimbTower.Game.Instance.StartGame(mainType, helpType);
            });
            GList MainCharactorList = MainView.GetChild("MainCharactor").asList;
            GList HelpCharactorList = MainView.GetChild("HelpCharactor").asList;
            foreach (CharactorTypeEnum a in Enum.GetValues(typeof(CharactorTypeEnum)))
            {
                AddItem(MainCharactorList, a);
                AddItem(HelpCharactorList, a);
            }
            MainCharactorList.onClickItem.Add(mainListOnClick);
            MainCharactorList.onClickItem.Call(MainCharactorList.GetChildAt(0));
            HelpCharactorList.onClickItem.Add(helpListOnClick);
        }
        void AddItem(GList list, CharactorTypeEnum type)
        {
            GComponent g = list.AddItemFromPool().asCom;
            g.text = type.ToString();
            g.data = type;
        }
        void mainListOnClick(EventContext x)
        {
            CharactorTypeEnum type = (CharactorTypeEnum)(((x.data) as GComponent).data);
            mainType = type;
        }
        void helpListOnClick(EventContext x)
        {
            CharactorTypeEnum type = (CharactorTypeEnum)(((x.data) as GComponent).data);
            helpType = type;
        }

        public override void OnEnter()
        {

        }
    }
}
