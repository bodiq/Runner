using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Managers;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private RankingRow rankingRowPrefab;
    [SerializeField] private Transform rankingParent;

    private List<RankingRow> _allRanking = new();

    private void OnEnable()
    {
        RefreshLeaderboardData();
    }

    private void RefreshLeaderboardData()
    {
        var sortedResults = GameManager.Instance.gameResults.results
            .OrderByDescending(res => res.gameScore)
            .ToList();
        
        for (var i = 0; i < sortedResults.Count; i++)
        {
            if (i < _allRanking.Count)
            {
                _allRanking[i].Initialize(sortedResults[i].gameCount, sortedResults[i].gameScore);
            }
            else
            {
                var newRow = Instantiate(rankingRowPrefab, rankingParent);
                newRow.Initialize(sortedResults[i].gameCount, sortedResults[i].gameScore);
                _allRanking.Add(newRow);
            }
        }
    }
    
}
