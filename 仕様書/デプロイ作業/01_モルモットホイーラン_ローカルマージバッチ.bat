@echo off

rem ########## �萔 ##########
rem �����[�U���Ƃɍ��كA�����@���|�W�g���ƕR�Â��G�N�X�v���[���[�̕ۑ���̐e
set USER_DIRECTORY="C:\Users\kzpaqu\Documents"
rem �����[�U���Ƃɍ��كA�����@���|�W�g���ƕR�Â��t�H���_��
set GIT_DIRECTORY="Japan_Game_Award_2021"
rem \
set EN="\\"
rem tmp�f�B���N�g��
set TMP_DIRECTORY="C:\tmp"
rem movie_sence�f�B���N�g��
set MOVIE_SENCE_DIRECTORY="Morumotto_ Wheerun_Movie\Assets"
rem title_sence�f�B���N�g��
set TITLE_SENCE_DIRECTORY="Morumotto_ Wheerun_Title\Assets"
rem select_sence�f�B���N�g��
set SELECT_SENCE_DIRECTORY="Morumotto_ Wheerun_Select\Assets"
rem main_sence�f�B���N�g��
set MAIN_SENCE_DIRECTORY="main_scene\CalamariTape\Assets"
rem �K���g�`���[�g�f�B���N�g��
set GANTT_CHART_DIRECTORY="�K���g�`���[�g"
rem �d�l���f�B���N�g��
set DOCUMENT_DIRECTORY="�d�l��"
rem ui_ux�f�B���N�g��
set UI_UX_DIRECTORY="ui_ux"

rem movie_sence�u�����`
set PROGRAMMER_MOVIE_SENCE_BRANCH="programmer/movie_sence"
rem title_sence�u�����`
set PROGRAMMER_TITLE_SENCE_BRANCH="programmer/title_sence"
rem select_sence�u�����`
set PROGRAMMER_SELECT_SENCE_BRANCH="programmer/select_sence"
rem main_sence�u�����`
set PROGRAMMER_MAIN_SENCE_BRANCH="programmer/main_sence"
rem �K���g�`���[�g�u�����`
set PLANNER_GANTT_CHART_BRANCH="planner/�K���g�`���[�g"
rem �d�l���u�����`
set PLANNER_DOCUMENT_BRANCH="planner/�d�l��"
rem ui_ux�u�����`
set DESIGNER_UI_UX_BRANCH="designer/ui_ux"

rem �L�[���[�h�����
set keyword=
set /P keyword="�L�[���[�h�����(entaro-):"

rem �L�[���[�h���`�F�b�N
if "%keyword%"=="entaro-" goto correctCase
if not "%keyword%"=="entaro-" goto notCorrectCase

rem �f�B���N�g�������݂���ꍇ
:correctCase

echo "���|�W�g���̃f�B���N�g���`�F�b�N"
set targetUserGitDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1%

rem �f�B���N�g�������݂��邩�`�F�b�N����
if exist %targetUserGitDirectory% goto findUserDirectorySuccessCase
if not exist %targetUserGitDirectory% goto findUserDirectoryErrorCase

rem �f�B���N�g�������݂���ꍇ
:findUserDirectorySuccessCase

echo "tmp�̃f�B���N�g���`�F�b�N"
set targetTmpDirectory=%TMP_DIRECTORY%

rem �f�B���N�g�������݂��邩�`�F�b�N����
if exist %targetTmpDirectory% goto findTmpDirectorySuccessCase
if not exist %targetTmpDirectory% goto findTmpDirectoryErrorCase

rem �f�B���N�g�������݂��Ȃ��ꍇ
:findTmpDirectoryErrorCase

echo "�y1�zmovie_sence�̃R�s�[���J�n"

rem tmp�t�H���_��C:\�֍쐬
set tmpDirectoryMovieSenceDirectory=%TMP_DIRECTORY:~0,-1%%EN:~2,-1%%MOVIE_SENCE_DIRECTORY:~1%
mkdir %tmpDirectoryMovieSenceDirectory%

rem movie_sence�`�F�b�N�A�E�g
set userDirectoryGitDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1%
cd %userDirectoryGitDirectory%
git checkout %PROGRAMMER_MOVIE_SENCE_BRANCH%

rem movie_sence�f�B���N�g����tmp�փR�s�[
set userGitMovieSenceDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1,-1%%EN:~2,-1%%MOVIE_SENCE_DIRECTORY:~1%
xcopy /s %userGitMovieSenceDirectory% %tmpDirectoryMovieSenceDirectory%

echo "movie_sence�̃R�s�[���I��"
rem pause

echo "�y2�ztitle_sence�̃R�s�[���J�n"

rem tmp�t�H���_��C:\�֍쐬
set tmpDirectoryTitleSenceDirectory=%TMP_DIRECTORY:~0,-1%%EN:~2,-1%%TITLE_SENCE_DIRECTORY:~1%
mkdir %tmpDirectoryTitleSenceDirectory%

rem title_sence�`�F�b�N�A�E�g
git checkout %PROGRAMMER_TITLE_SENCE_BRANCH%

rem title_sence�f�B���N�g����tmp�փR�s�[
set userGitTitleSenceDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1,-1%%EN:~2,-1%%TITLE_SENCE_DIRECTORY:~1%
xcopy /s %userGitTitleSenceDirectory% %tmpDirectoryTitleSenceDirectory%

echo "title_sence�̃R�s�[���I��"
rem pause

echo "�y3�zselect_sence�̃R�s�[���J�n"

rem tmp�t�H���_��C:\�֍쐬
set tmpDirectorySelectSenceDirectory=%TMP_DIRECTORY:~0,-1%%EN:~2,-1%%SELECT_SENCE_DIRECTORY:~1%
mkdir %tmpDirectorySelectSenceDirectory%

rem select_sence�`�F�b�N�A�E�g
git checkout %PROGRAMMER_SELECT_SENCE_BRANCH%

rem select_sence�f�B���N�g����tmp�փR�s�[
set userGitSelectSenceDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1,-1%%EN:~2,-1%%SELECT_SENCE_DIRECTORY:~1%
xcopy /s %userGitSelectSenceDirectory% %tmpDirectorySelectSenceDirectory%

echo "select_sence�̃R�s�[���I��"
rem pause

echo "�y4�zmain_sence�̃R�s�[���J�n"

rem tmp�t�H���_��C:\�֍쐬
set tmpDirectoryMainSenceDirectory=%TMP_DIRECTORY:~0,-1%%EN:~2,-1%%MAIN_SENCE_DIRECTORY:~1%
mkdir %tmpDirectoryMainSenceDirectory%

rem main_sence�`�F�b�N�A�E�g
git checkout %PROGRAMMER_MAIN_SENCE_BRANCH%

rem main_sence�f�B���N�g����tmp�փR�s�[
set userGitMainSenceDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1,-1%%EN:~2,-1%%MAIN_SENCE_DIRECTORY:~1%
xcopy /s %userGitMainSenceDirectory% %tmpDirectoryMainSenceDirectory%

echo "main_sence�̃R�s�[���I��"
rem pause

echo "�y5�z�K���g�`���[�g�̃R�s�[���J�n"

rem tmp�t�H���_��C:\�֍쐬
set tmpDirectoryGanttChartDirectory=%TMP_DIRECTORY:~0,-1%%EN:~2,-1%%GANTT_CHART_DIRECTORY:~1%
mkdir %tmpDirectoryGanttChartDirectory%

rem �K���g�`���[�g�`�F�b�N�A�E�g
git checkout %PLANNER_GANTT_CHART_BRANCH%

rem �K���g�`���[�g�f�B���N�g����tmp�փR�s�[
set userGitGanttChartDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1,-1%%EN:~2,-1%%GANTT_CHART_DIRECTORY:~1%
xcopy /s %userGitGanttChartDirectory% %tmpDirectoryGanttChartDirectory%

echo "�K���g�`���[�g�̃R�s�[���I��"
rem pause

echo "�y5�z�d�l���̃R�s�[���J�n"

rem tmp�t�H���_��C:\�֍쐬
set tmpDirectoryDocumentDirectory=%TMP_DIRECTORY:~0,-1%%EN:~2,-1%%DOCUMENT_DIRECTORY:~1%
mkdir %tmpDirectoryDocumentDirectory%

rem �d�l���`�F�b�N�A�E�g
git checkout %PLANNER_DOCUMENT_BRANCH%

rem �d�l���f�B���N�g����tmp�փR�s�[
set userGitDocumentDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1,-1%%EN:~2,-1%%DOCUMENT_DIRECTORY:~1%
xcopy /s %userGitDocumentDirectory% %tmpDirectoryDocumentDirectory%

echo "�d�l���̃R�s�[���I��"
rem pause

echo "�y6�zui_ux�̃R�s�[���J�n"

rem tmp�t�H���_��C:\�֍쐬
set tmpDirectoryUiUxDirectory=%TMP_DIRECTORY:~0,-1%%EN:~2,-1%%UI_UX_DIRECTORY:~1%
mkdir %tmpDirectoryUiUxDirectory%

rem ui_ux�`�F�b�N�A�E�g
git checkout %DESIGNER_UI_UX_BRANCH%

rem ui_ux�f�B���N�g����tmp�փR�s�[
set userGitUiUxDirectory=%USER_DIRECTORY:~0,-1%%EN:~2,-1%%GIT_DIRECTORY:~1,-1%%EN:~2,-1%%UI_UX_DIRECTORY:~1%
xcopy /s %userGitUiUxDirectory% %tmpDirectoryUiUxDirectory%

echo "ui_ux�̃R�s�[���I��"
pause

explorer %TMP_DIRECTORY%
exit /b

rem �f�B���N�g�������݂��Ȃ��ꍇ
:findUserDirectoryErrorCase
echo "�f�B���N�g�������݂��܂���ł����B"
pause
exit /b

rem �f�B���N�g�������݂���ꍇ
:findTmpDirectorySuccessCase
echo "���Ƀf�B���N�g�������݂��܂��B�ȉ��̃f�B���N�g�����폜���ĉ������B"
echo %targetTmpDirectory%
pause
exit /b

rem �f�B���N�g�������݂��Ȃ��ꍇ
:notCorrectCase
echo "�Ԉ�����L�[���[�h�B"
pause
