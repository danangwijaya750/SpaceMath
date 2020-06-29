using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public static string PLAYER_PREF_NAME="PlayerName";
    public static string [] PREF_STAGE = {"stage1","stage2","stage3"};
    public static string PLAYER_SCORE_PREF="PlayerScore";
    public static string [ , ] PREF_STAGE_LEVEL = 
    {
        {"stage1Level1","stage1Level2","stage1Level3","stage1Level4","stage1Level5","stage1LevelBoss"},
        {"stage2Level1","stage2Level2","stage2Level3","stage2Level4","stage2Level5","stage2LevelBoss"},
        {"stage3Level1","stage3Level2","stage3Level3","stage3Level4","stage3Level5","stage3LevelBoss"}
    };

     public static string [ , ] PREF_STAGE_LEVEL_SCORE = 
    {
        {"stage1Level1Score","stage1Level2Score","stage1Level3Score","stage1Level4Score","stage1Level5Score","stage1LevelBossScore"},
        {"stage2Level1Score","stage2Level2Score","stage2Level3Score","stage2Level4Score","stage2Level5Score","stage2LevelBossScore"},
        {"stage3Level1Score","stage3Level2Score","stage3Level3Score","stage3Level4Score","stage3Level5Score","stage3LevelBossScore"}
    };

    public static int [ , ] enemiesPerLevel = {
        {5,8,10,10,15,15},
        {5,8,10,10,15,15},
        {8,10,15,18,18,18}
    };

    public static int [ ] enemiesScores = {10,15,20};
    public static int [ ] enemiesSpeed = {10,10,10};

    public static string [] storyText={
    "Selamat Datang di Planet C-53 tahun 2123.",
    "Pagi yang cerah di kota Ci-fiv, Seperti hari biasanya Soni sedang bersiap untuk berolahraga",
    "Soni adalah seorang  teknisi muda pesawat luar angkasa, dia belajar mengenai pesawat semenjak kecil, bersama Pak Budi yang seorang ilmuwan pesawat",
    "Tidak berselang lama saat Soni mulai berolahraga, tiba-tiba kota Ci-fiv diserang oleh pasukan alien dari Planet bernama Kalix  yang ingin menginvasi Planet C-53", 
    "\"Kalian para Penduduk Planet C-53, saya adalah Boris pemimpin pasukan dari Kerajaan Matichs. Saya datang untuk menginvasi Planet kalian ha...ha...ha... \"",
    "\"Serahkanlah planet kalian dan tunduklah kepada kerajaan Matichs atas perintah Raja Kami Mr.Lambda\"",
    "\"Tidak!!! kami akan tetap mempertahankan Planet kami\", Soni bersorak sambil melawan dengan menembakan laser yang dia bawa kearah pesawat Boris tapi tidak mempan",
    "Karena Pasukan Matichs hanya dapat dikalahkan dengan peluru yang berisi kode untuk dapat langsung menghancurkan mereka",
    "Kode tersebut dapat dipecahkan dengan menjawab soal Matematika",
    "Karena Boris tertarik dengan perlawan yang diberikan Soni dan para penduduk C-53, maka Boris menyatakan perang dan menangkap Elita adik Soni sebagai sandera",
    "Soni harus menyelamatkan Planetnya dan adiknya yang diculik oleh Boris, serta mengalahkan Mr.Lambda dan para pasukannya beserta Boris.",
    "Bantulah Soni dan bekerjasamalah dengan Pak Budi untuk membuat pesawat luar angkasa dan selamatkanlah adik Soni."};
}
