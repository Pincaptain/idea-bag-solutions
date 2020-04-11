import React, { Component } from 'react';

import { Card, CardContent, CardActions, Button, Typography } from '@material-ui/core';

export default class AlarmEntry extends Component {
    render() {
        return (
            <div>
                <Card style={{
                    maxWidth: 275,
                }} variant="outlined">
                    <CardContent>
                        <Typography variant="h5" component="h2">
                            Workshop
                        </Typography>
                        <Typography variant="p" color="textSecondary" style={{
                            marginTop: 25,
                            marginBottom: 25,
                        }}>
                            2020/04/11 01:27 AM
                        </Typography>
                        <Typography variant="body2" component="p">
                            You organized a small workshop with the crew from Santa Monica. Be there on time.
                        </Typography>
                    </CardContent>
                    <CardActions>
                        <Button size="small" color="secondary" variant="contained">Remove</Button>
                    </CardActions>
                </Card>
            </div>
        );
    }
}