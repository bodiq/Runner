using System.Collections.Generic;
using System.Linq;
using Managers;
using UnityEngine;
using Zenject;

namespace UI
{
    public class Leaderboard : MonoBehaviour
    {
        [SerializeField] private RankingRow rankingRowPrefab;
        [SerializeField] private Transform rankingParent;

        private List<RankingRow> _allRanking = new();
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        private void OnEnable()
        {
            RefreshLeaderboardData();
        }

        private void RefreshLeaderboardData()
        {
            var sortedResults = _gameManager.gameResults.results
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
}
