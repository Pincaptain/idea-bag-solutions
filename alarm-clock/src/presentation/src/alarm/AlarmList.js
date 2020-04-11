import React, { Component } from 'react';

import Grid from '@material-ui/core/Grid';
import { Typography, Container } from '@material-ui/core';

import AlarmEntry from './AlarmEntry';

export default class AlarmList extends Component {
    render() {
        return (
            <Container>
                <Typography variant="h4" style={{
                    marginBottom: 8,
                }}>
                    Alarms
                </Typography>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={6} md={4} xl={3}>
                        <AlarmEntry />
                    </Grid>
                    <Grid item xs={12} sm={6} md={4} xl={3}>
                        <AlarmEntry />
                    </Grid>
                    <Grid item xs={12} sm={6} md={4} xl={3}>
                        <AlarmEntry />
                    </Grid>
                    <Grid item xs={12} sm={6} md={4} xl={3}>
                        <AlarmEntry />
                    </Grid>
                </Grid>
            </Container>
        );
    }
}