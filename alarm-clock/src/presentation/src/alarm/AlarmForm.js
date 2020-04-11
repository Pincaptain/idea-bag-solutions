import React, { Component } from 'react';

import AlarmIcon from '@material-ui/icons/Alarm';
import { IconButton, InputAdornment, Container, TextField, Grid, Button } from "@material-ui/core";
import AddAlarmIcon from '@material-ui/icons/AddAlarm';
import { KeyboardDateTimePicker } from '@material-ui/pickers';

export default class AlarmForm extends Component {
    state = {
        date: new Date(),
        title: "",
        description: "",
    };

    onDateChange = date => this.setState({ date });
    onTitleChange = event => {
        this.setState({
            title: event.target.value,
        });
    };
    onDescriptionChange = event => {
        this.setState({
            description: event.target.value,
        });
    };

    onAdd = () => console.log(this.state.date);

    render() {
        return (
            <Container style={{
                marginBottom: 32,
            }}>
                <Grid container direction="row" justify="flex-start" alignItems="flex-start" spacing={3}>
                    <Grid item xs={12}>
                        <KeyboardDateTimePicker
                            value={this.state.date}
                            onChange={this.onDateChange}
                            label="Alarm"
                            onError={console.log}
                            minDate={new Date()}
                            format="yyyy/MM/dd hh:mm a"
                            helperText="Setup your alarm date and time"
                            InputProps={{
                                endAdornment: (
                                    <InputAdornment position="end">
                                        <IconButton>
                                            <AlarmIcon />
                                        </IconButton>
                                    </InputAdornment>
                                ),
                            }} />
                    </Grid>
                    <Grid item>
                        <TextField
                            onChange={this.onTitleChange}
                            value={this.state.title}
                            label="Title"
                            variant="filled"
                            helperText="Alarm title text" />
                    </Grid>
                    <Grid item>
                        <TextField
                            onChange={this.onDescriptionChange}
                            value={this.state.description}
                            label="Description"
                            multiline
                            rows={10}
                            variant="filled"
                            helperText="Alarm description text" />
                    </Grid>
                    <Grid item xs={12}>
                        <Button
                            variant="contained"
                            color="primary"
                            size="large"
                            fullWidth
                            startIcon={<AddAlarmIcon />} >
                            Add
                        </Button>
                    </Grid>
                </Grid>
            </Container>
        );
    }
}