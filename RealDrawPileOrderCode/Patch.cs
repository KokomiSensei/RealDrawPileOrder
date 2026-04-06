using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Nodes.Cards;
using MegaCrit.Sts2.Core.Nodes.Screens;
using MegaCrit.Sts2.Core.Nodes.Screens.CardLibrary;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RealDrawPileOrder.RealDrawPileOrderCode;

[HarmonyPatch(typeof(NCardPileScreen), "OnPileContentsChanged")]
public static class TargetClass_MethodName_Patch {

    static readonly AccessTools.FieldRef<NCardPileScreen, NCardGrid> _gridRef = AccessTools.FieldRefAccess<NCardPileScreen, NCardGrid>("_grid");

    [Conditional("DEBUG")]
    private static void printCards(CardPile pile) {
        List<CardModel> cards = pile.Cards.ToList();
        MainFile.Logger.Info("OnPileContentsChanged was called!");
        MainFile.Logger.Debug("Pile type: " + pile.Type);
        MainFile.Logger.Debug("Cards[" + cards.Count + "]:");
        foreach (CardModel card in cards) {
            MainFile.Logger.Debug("Card: " + card.Id.Entry + ", Rarity: " + card.Rarity);
        }
    }


    static bool Prefix(NCardPileScreen __instance) {
        printCards(__instance.Pile);

        List<CardModel> list = __instance.Pile.Cards.ToList();
        /*
        // Removed the following if statement:
        if (__instance.Pile.Type == PileType.Draw) {
            list.Sort((CardModel c1, CardModel c2) => (c1.Rarity != c2.Rarity) ? c1.Rarity.CompareTo(c2.Rarity) : string.Compare(c1.Id.Entry, c2.Id.Entry, StringComparison.Ordinal));
        } 
        */

        NCardGrid grid = _gridRef(__instance);
        PileType type = __instance.Pile.Type;
        int num = 1;
        List<SortingOrders> list2 = new List<SortingOrders>(num);
        CollectionsMarshal.SetCount(list2, num);
        Span<SortingOrders> span = CollectionsMarshal.AsSpan(list2);
        int index = 0;
        span[index] = SortingOrders.Ascending;
        grid.SetCards(list, type, list2);

        bool runOriginal = false;
        return runOriginal;
    }

}
