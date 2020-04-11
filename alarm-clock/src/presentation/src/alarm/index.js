import React, { Component } from 'react';

import { Container } from "@material-ui/core";

import AlarmForm from './AlarmForm';
import AlarmList from './AlarmList';

export default class Alarm extends Component {
    render() {
        return (
            <Container style={{
                padding: 32,
            }}>
                <AlarmForm />
                <AlarmList />
            </Container>
        );
    }
}