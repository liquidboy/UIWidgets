﻿using System;
using System.Collections.Generic;
using Unity.UIWidgets.engine;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.material;
using Unity.UIWidgets.painting;
using Unity.UIWidgets.rendering;
using Unity.UIWidgets.service;
using Unity.UIWidgets.ui;
using Unity.UIWidgets.widgets;
using TextStyle = Unity.UIWidgets.painting.TextStyle;

namespace UIWidgetsSample {
    public class TextInputCanvas : WidgetCanvas {
        public class TextInputSample : StatefulWidget {
            public readonly string title;

            public TextInputSample(Key key = null, string title = null) : base(key) {
                this.title = title;
            }

            public override State createState() {
                return new _TextInputSampleState();
            }
        }

        protected override Widget getWidget() {
            return new TextInputSample(key: null, title: this.gameObject.name);
        }

        class _TextInputSampleState : State<TextInputSample> {
            
            TextEditingController titleController = new TextEditingController("");
            TextEditingController descController = new TextEditingController("");
            FocusNode _titleFocusNode;
            FocusNode _descFocusNode;

            public override void initState() {
                base.initState();
                this._titleFocusNode = new FocusNode();
                this._descFocusNode = new FocusNode();
            }

            public override void dispose() {
                this._titleFocusNode.dispose();
                this._descFocusNode.dispose();
                base.dispose();
            }

            Widget title() {
                return new Container(child:new Text(this.widget.title ?? "", textAlign: TextAlign.center,
                    style: new TextStyle(fontSize: 24, fontWeight: FontWeight.w700)), margin:EdgeInsets.only(bottom:20));
            }

            Widget titleInput() {
                return new Row(
                    children: new List<Widget>(
                    ) {
                        new SizedBox(width: 100, child: new Text("Title")),
                        new Flexible(child: new Container(
                            decoration: new BoxDecoration(border: Border.all(new Color(0xFF000000), 1)),
                            padding: EdgeInsets.fromLTRB(8, 0, 8, 0),
                            child: new EditableText(maxLines: 1,
                                controller: this.titleController,
                                selectionControls: MaterialUtils.materialTextSelectionControls,
                                autofocus: true,
                                focusNode: new FocusNode(),
                                style: new TextStyle(
                                    fontSize: 18,
                                    height: 1.5f,
                                    color: new Color(0xFF1389FD)
                                ),
                                selectionColor: Color.fromARGB(255, 255, 0, 0),
                                cursorColor: Color.fromARGB(255, 0, 0, 0))
                        )),
                    }
                );
            }

            Widget descInput() {
                return new Container(
                    margin: EdgeInsets.fromLTRB(0, 10, 0, 10),
                    child: new Row(
                        children: new List<Widget>(
                        ) {
                            new SizedBox(width: 100, child: new Text("Description")),
                            new Flexible(child: new Container(
                                height: 200,
                                decoration: new BoxDecoration(border: Border.all(new Color(0xFF000000), 1)),
                                padding: EdgeInsets.fromLTRB(8, 0, 8, 0),
                                child: new EditableText(maxLines: 200,
                                    controller: this.descController,
                                    selectionControls: MaterialUtils.materialTextSelectionControls,
                                    focusNode: new FocusNode(),
                                    style: new TextStyle(
                                        fontSize: 18,
                                        height: 1.5f,
                                        color: new Color(0xFF1389FD)
                                    ),
                                    selectionColor: Color.fromARGB(255, 255, 0, 0),
                                    cursorColor: Color.fromARGB(255, 0, 0, 0))
                            )),
                        }
                    ));
            }

            public override Widget build(BuildContext context) {
                var container = new Container(
                    padding: EdgeInsets.all(10),
                    decoration: new BoxDecoration(color: new Color(0x7F000000),
                        border: Border.all(color: Color.fromARGB(255, 255, 0, 0), width: 5),
                        borderRadius: BorderRadius.all(2)),
                    child: new Column(
                        crossAxisAlignment: CrossAxisAlignment.stretch,
                        children: new List<Widget> {
                            this.title(),
                            this.titleInput(),
                            this.descInput(),
                        }
                    )
                );
                return container;
            }
        }
    }
    

}
