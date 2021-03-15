import React, { useState } from 'react';
import { Session } from '../models/session.model';
import SessionCard from './session-card';

import './app.css';
import { Typography } from '@material-ui/core';

const sessions: Array<Session> = [
  { id: 0, title: "Introduction to Ionic", speaker: "CHRISTOPHE COENRAETS", time: "9:40am", room: "Ballroom A", description: "In this session, you'll learn how to build a native-like mobile application using the Ionic Framework, AngularJS, and Cordova." },
  { id: 1, title: "ReactJS in 50 Minutes", speaker: "LISA SMITH", time: "10:10am", room: "Ballroom B", description: "In this session, you'll learn everything you need to know to start building next-gen JavaScript applications using AngularJS." },
  { id: 2, title: "Contributing to Apache Cordova", speaker: "JOHN SMITH", time: "11:10am", room: "Ballroom A", description: "In this session, John will tell you all you need to know to start contributing to Apache Cordova and become an Open Source Rock Star." },
  { id: 3, title: "Mobile Performance Techniques", speaker: "JESSICA WONG", time: "3:10Pm", room: "Ballroom B", description: "In this session, you will learn performance techniques to speed up your mobile application." },
  { id: 4, title: "Building Modular Applications", speaker: "LAURA TAYLOR", time: "2:00pm", room: "Ballroom A", description: "Join Laura to learn different approaches to build modular JavaScript applications." }
];


const App = () => {
  const [totalVotes, setTotalVotes] = useState(0);

  const sessionsList = sessions.map((session) =>
    <SessionCard session={session} onVote={() => setTotalVotes(totalVotes + 1) }></SessionCard>);

  return (
    <div>
      <div className="header">
        <Typography variant="subtitle1" gutterBottom>
          Number of votes: {totalVotes}
        </Typography>
      </div>
      <div>
        {sessionsList}
      </div>
    </div>
  );
}

export default App;
