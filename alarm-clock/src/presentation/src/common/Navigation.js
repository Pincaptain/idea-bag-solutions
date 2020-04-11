import React, { Component } from "react";

import { AppBar, Toolbar, Typography } from '@material-ui/core';

export default class Navigation extends Component {
    render() {
        return (
            <div style={{
                flexGrow: 1,
                "-webkit-app-region": "drag",
            }}>
                <AppBar position="static" color="inherit">
                    <Toolbar>
                        <Typography variant="h6" style={{
                            flexGrow: 1,
                        }}>
                            Alarm Clock
                        </Typography>
                    </Toolbar>
                </AppBar>
            </div>
        );
    }
}