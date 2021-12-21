using System.Collections.Generic;

namespace MikuMikuPlayer
{
    public interface IPlayer
    {
        bool hasMedia();

        PlayerStatus getStatus();

        void pause();

        void play();

        void stop();

        void prev();

        void next();

        void toggleReplay();

        void toggleRandom();

        double getCurrentPosition();

        double getDuration();

        double getAngle();

        void appendMedia(string file);

        void removeMedia(int index);

        void playInList(int index);

        int getVolume();

        void setVolume(int volume);

        bool isReplay();

        bool isRandom();

        void clearPlayList();

        IList<string> getPlayList();

        IPlayerControl getPlayerControl();

        void toggleFullScreen();

        void registerPlayer();

        void toggleUI();

        bool isMute();

        string getCurrentPlay();
    }
}