

/*
This is a UI file (.ui.qml) that is intended to be edited in Qt Design Studio only.
It is supposed to be strictly declarative and only uses a subset of QML. If you edit
this file manually, you might introduce QML code that is not supported by Qt Design Studio.
Check out https://doc.qt.io/qtcreator/creator-quick-ui-forms.html for details on .ui.qml files.
*/
import QtQuick 6.7
import QtQuick.Controls 6.7
import Piano

Rectangle {
    id: rectangle
    width: 795
    height: 501

    color: Constants.backgroundColor
    state: "StateOff"

    Button {
        id: btnOff
        x: 49
        y: 63
        text: qsTr("Off")
    }

    Button {
        id: btnRtLive
        x: 215
        y: 63
        text: qsTr("Remote Live")
    }

    Button {
        id: btnRtCtrl
        x: 348
        y: 63
        text: qsTr("Remote Control")
    }

    Button {
        id: btnPlay
        x: 654
        y: 63
        text: qsTr("Play")
    }

    Button {
        id: btnPlaySheet
        x: 523
        y: 63
        text: qsTr("Play sheet")
    }

    Page {
        id: pgPlay
        x: 1
        y: 197
        width: 795
        height: 304
        visible: false

        Button {
            id: button
            x: 107
            y: 99
            text: qsTr("Button")
        }
    }

    Page {
        id: pgPlaySheet
        x: 1
        y: 197
        width: 795
        height: 304
        visible: false

        Button {
            id: button5
            x: 481
            y: 112
            text: qsTr("Play")
        }

        ComboBox {
            id: comboBox
            x: 208
            y: 112
            width: 249
            height: 40
        }
    }

    Page {
        id: pgRtCtrl
        x: 1
        y: 197
        width: 795
        height: 304
        visible: false

        Label {
            id: label2
            x: 384
            y: 42
            text: qsTr("Label")
        }

        Label {
            id: label3
            x: 384
            y: 77
            text: qsTr("Label")
        }
    }

    Page {
        id: pgRtLive
        x: 1
        y: 197
        width: 795
        height: 304
        visible: false

        Label {
            id: label
            x: 311
            y: 111
            text: qsTr("Label")
        }

        Label {
            id: label1
            x: 384
            y: 91
            text: qsTr("Label")
        }
    }

    states: [
        State {
            name: "StateOff"
            when: btnOff.pressed
        },
        State {
            name: "StateRtLive"
            when: btnRtLive.pressed

            PropertyChanges {
                target: pgRtLive
                visible: true
            }

            PropertyChanges {
                target: button
                text: qsTr("Pin1")
            }

            PropertyChanges {
                target: label
                x: 363
                y: 52
                text: qsTr("Key recieved:")
            }
        },
        State {
            name: "StateRtCtrl"
            when: btnRtCtrl.pressed

            PropertyChanges {
                target: pgRtCtrl
                visible: true
            }

            PropertyChanges {
                target: label2
                x: 362
                y: 40
                text: qsTr("Midi recieved")
            }
        },
        State {
            name: "StatePlaySheet"
            when: btnPlaySheet.pressed

            PropertyChanges {
                target: pgPlaySheet
                visible: true
            }
        },
        State {
            name: "StatePlay"
            when: btnPlay.pressed

            PropertyChanges {
                target: pgPlay
                visible: true
            }

            PropertyChanges {
                target: button
                text: qsTr("Pin1")
            }
        }
    ]
}
