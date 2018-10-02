using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GPGS : MonoBehaviour {
    public string papanperingkat = "CgkI-frW5qUVEAIQBA";
    public string andamantap = "CgkI-frW5qUVEAIQAw";

    void Start() {
        // Debug untuk Google Play Games
        PlayGamesPlatform.DebugLogEnabled = true;

        // Untuk mengaktifkan Google Play Games
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) =>
        {
            if (success) {
                Debug.Log("Berhasil Login");
            }
            else {
                Debug.Log("Gagal Login");
            }
        });
    }

    //Membuka Achievement
    public void UnlockAchievement() {
        if (Social.localUser.authenticated) {
            Social.ReportProgress(andamantap, 150.0f, (bool success) => {
                if (success) {
                    Debug.Log("Achievement Berhasil");
                }
                else {
                    Debug.Log("Achievement Gagal");
                }
            });
        }
    }

    //Post skor ke Leaderboard
    public void PostScoreLeaderBoard() {
        if (Social.localUser.authenticated) {
            Social.ReportScore(100, papanperingkat, (bool success) => {
                if (success) {
                    Debug.Log("Update Score Berhasil");
                }
                else {
                    Debug.Log("Update Score Gagal");
                }
            });
        }
    }

    //Menampilkan Leaderboard secara detail
    public void ShowSpecificLeaderboard() {
        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(papanperingkat);
    }

    //Menampilkan Achievement
    public void ShowAchievementUI() {
        Social.ShowAchievementsUI();
    }
}