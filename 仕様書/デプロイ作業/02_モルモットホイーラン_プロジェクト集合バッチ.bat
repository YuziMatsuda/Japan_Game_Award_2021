@echo off

rem ########## �萔 ##########
rem �����[�U���Ƃɍ��كA�����@���|�W�g���ƕR�Â��G�N�X�v���[���[�̕ۑ���̐e
set USER_DIRECTORY="C:\Users\kzpaqu\Documents"
rem �����[�U���Ƃɍ��كA�����@���|�W�g���ƕR�Â��t�H���_��
set GIT_DIRECTORY="Japan_Game_Award_2021"
rem \
set EN="\\"
rem movie_sence�f�B���N�g��
set MOVIE_SENCE_DIRECTORY="Morumotto_ Wheerun_Movie\Assets"
rem title_sence�f�B���N�g��
set TITLE_SENCE_DIRECTORY="Morumotto_ Wheerun_Title\Assets"
rem select_sence�f�B���N�g��
set SELECT_SENCE_DIRECTORY="Morumotto_ Wheerun_Select\Assets"
rem main_sence�f�B���N�g��
set MAIN_SENCE_DIRECTORY="main_scene\CalamariTape\Assets"
rem main_sence�f�B���N�g��(�V)
set NEW_MAIN_SENCE_DIRECTORY="main_scene\Assets"
rem Morumotto_Wheerun�f�B���N�g��
set MORUMOTTO_WHEERUN_DIRECTORY="Morumotto_Wheerun\Assets"
rem �s�v�f�B���N�g��
set SCENES_DIRECTORY="Scenes"
rem �s�v�t�@�C��
set SCENES_DIRECTORY_FILE="Scenes.meta"

rem �L�[���[�h�����
set keyword=
set /P keyword="�L�[���[�h�����(entaro-):"

rem �L�[���[�h���`�F�b�N
if "%keyword%"=="entaro-" goto correctCase
if not "%keyword%"=="entaro-" goto notCorrectCase

rem �L�[���[�h���������ꍇ
:correctCase

echo "���|�W�g���̃f�B���N�g���`�F�b�N"
set targetUserGitDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1%

rem �f�B���N�g�������݂��邩�`�F�b�N����
if exist %targetUserGitDirectory% goto findUserDirectorySuccessCase
if not exist %targetUserGitDirectory% goto findUserDirectoryErrorCase

rem �f�B���N�g�������݂���ꍇ
:findUserDirectorySuccessCase

echo "movie_sence�̃f�B���N�g���`�F�b�N"
set targetUserGitMovieSenceDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1,-1%%EN:~2,-1%%MOVIE_SENCE_DIRECTORY:~1%
echo %targetUserGitMovieSenceDirectory%

rem �f�B���N�g�������݂��邩�`�F�b�N����
if exist %targetUserGitMovieSenceDirectory% goto findUserMovieSenceDirectorySuccessCase
if not exist %targetUserGitMovieSenceDirectory% goto findUserMovieSenceDirectoryErrorCase

rem �f�B���N�g�������݂���ꍇ
:findUserMovieSenceDirectorySuccessCase

echo "title_sence�̃f�B���N�g���`�F�b�N"
set targetUserGitTitleSenceDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1,-1%%EN:~2,-1%%TITLE_SENCE_DIRECTORY:~1%
echo %targetUserGitTitleSenceDirectory%

rem �f�B���N�g�������݂��邩�`�F�b�N����
if exist %targetUserGitTitleSenceDirectory% goto findUserTitleSenceDirectorySuccessCase
if not exist %targetUserGitTitleSenceDirectory% goto findUserTitleSenceDirectoryErrorCase

rem �f�B���N�g�������݂���ꍇ
:findUserTitleSenceDirectorySuccessCase

echo "select_sence�̃f�B���N�g���`�F�b�N"
set targetUserGitSelectSenceDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1,-1%%EN:~2,-1%%SELECT_SENCE_DIRECTORY:~1%
echo %targetUserGitSelectSenceDirectory%

rem �f�B���N�g�������݂��邩�`�F�b�N����
if exist %targetUserGitSelectSenceDirectory% goto findUserSelectSenceDirectorySuccessCase
if not exist %targetUserGitSelectSenceDirectory% goto findUserSelectSenceDirectoryErrorCase

rem �f�B���N�g�������݂���ꍇ
:findUserSelectSenceDirectorySuccessCase

echo "main_sence�̃f�B���N�g���`�F�b�N"
set targetUserGitMainSenceDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1,-1%%EN:~2,-1%%MAIN_SENCE_DIRECTORY:~1%
echo %targetUserGitMainSenceDirectory%

rem �f�B���N�g�������݂��邩�`�F�b�N����
if exist %targetUserGitMainSenceDirectory% goto findUserMainSenceDirectorySuccessCase
if not exist %targetUserGitMainSenceDirectory% goto findUserMainSenceDirectoryErrorCase

rem �f�B���N�g�������݂���ꍇ
:findUserMainSenceDirectorySuccessCase

echo "Morumotto_Wheerun�̃f�B���N�g���`�F�b�N"
set targetUserGitMorumottoWheerunDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1,-1%%EN:~2,-1%%MORUMOTTO_WHEERUN_DIRECTORY:~1%
echo %targetUserGitMorumottoWheerunDirectory%

rem �f�B���N�g�������݂��邩�`�F�b�N����
if exist %targetUserGitMorumottoWheerunDirectory% goto findUserMorumottoWheerunDirectorySuccessCase
if not exist %targetUserGitMorumottoWheerunDirectory% goto findUserMorumottoWheerunDirectoryErrorCase

rem �f�B���N�g�������݂���ꍇ
:findUserMorumottoWheerunDirectorySuccessCase

rem Morumotto_Wheerun��Asset�f�B���N�g������movie_sence�f�B���N�g�����쐬
set mergeMovieSenceDirectory=%targetUserGitMorumottoWheerunDirectory:~0,-1%%EN:~2,-1%%MOVIE_SENCE_DIRECTORY:~1%
mkdir %mergeMovieSenceDirectory%

rem Morumotto_Wheerun��Asset�f�B���N�g������title_sence�f�B���N�g�����쐬
set mergeTitleSenceDirectory=%targetUserGitMorumottoWheerunDirectory:~0,-1%%EN:~2,-1%%TITLE_SENCE_DIRECTORY:~1%
mkdir %mergeTitleSenceDirectory%

rem Morumotto_Wheerun��Asset�f�B���N�g������select_sence�f�B���N�g�����쐬
set mergeSelectSenceDirectory=%targetUserGitMorumottoWheerunDirectory:~0,-1%%EN:~2,-1%%SELECT_SENCE_DIRECTORY:~1%
mkdir %mergeSelectSenceDirectory%

rem Morumotto_Wheerun��Asset�f�B���N�g������main_sence�f�B���N�g�����쐬
set mergeMainSenceDirectory=%targetUserGitMorumottoWheerunDirectory:~0,-1%%EN:~2,-1%%NEW_MAIN_SENCE_DIRECTORY:~1%
mkdir %mergeMainSenceDirectory%

rem movie_sence�f�B���N�g����Morumotto_Wheerun�փR�s�[
xcopy /s %targetUserGitMovieSenceDirectory% %mergeMovieSenceDirectory%

rem title_sence�f�B���N�g����Morumotto_Wheerun�փR�s�[
xcopy /s %targetUserGitTitleSenceDirectory% %mergeTitleSenceDirectory%

rem select_sence�f�B���N�g����Morumotto_Wheerun�փR�s�[
xcopy /s %targetUserGitSelectSenceDirectory% %mergeSelectSenceDirectory%

rem main_sence�f�B���N�g����Morumotto_Wheerun�փR�s�[
xcopy /s %targetUserGitMainSenceDirectory% %mergeMainSenceDirectory%

rem �s�v�f�B���N�g�����폜
echo "�s�v�f�B���N�g�����폜"
set deleteScenesDirectory=%targetUserGitMorumottoWheerunDirectory:~0,-1%%EN:~2,-1%%SCENES_DIRECTORY:~1%
echo %deleteScenesDirectory%
rmdir /s %deleteScenesDirectory%
echo "�s�v�t�@�C�����폜"
set deleteScenesFile=%targetUserGitMorumottoWheerunDirectory:~0,-1%%EN:~2,-1%%SCENES_DIRECTORY_FILE:~1%
echo %deleteScenesFile%
del %deleteScenesFile%

pause
exit /b

rem �f�B���N�g�������݂��Ȃ��ꍇ
:findUserDirectoryErrorCase
echo "�f�B���N�g�������݂��܂���ł����B"
pause
exit /b

rem �f�B���N�g�������݂��Ȃ��ꍇ
:findUserMovieSenceDirectoryErrorCase
echo "movie_sence�̃f�B���N�g�������݂��܂���ł����B"
pause
exit /b

rem �f�B���N�g�������݂��Ȃ��ꍇ
:findUserTitleSenceDirectoryErrorCase
echo "title_sence�̃f�B���N�g�������݂��܂���ł����B"
pause
exit /b

rem �f�B���N�g�������݂��Ȃ��ꍇ
:findUserSelectSenceDirectoryErrorCase
echo "select_sence�̃f�B���N�g�������݂��܂���ł����B"
pause
exit /b

rem �f�B���N�g�������݂��Ȃ��ꍇ
:findUserMainSenceDirectoryErrorCase
echo "main_sence�̃f�B���N�g�������݂��܂���ł����B"
pause
exit /b

rem �f�B���N�g�������݂��Ȃ��ꍇ
:findUserMorumottoWheerunDirectoryErrorCase
echo "Morumotto_Wheerun�̃f�B���N�g�������݂��܂���ł����B"
pause
exit /b

rem �L�[���[�h���������Ȃ��ꍇ
:notCorrectCase
echo "�Ԉ�����L�[���[�h�B"
pause
