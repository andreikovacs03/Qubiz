import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Modal from '@material-ui/core/Modal';
import { Session } from 'shared/models/session.model';
import { Backdrop, Button, ButtonGroup, Fade, Grid, TextField, Typography } from '@material-ui/core';
import EditIcon from '@material-ui/icons/Edit';

import './session-card-edit-form.css'

type Props = {
    session: Session;
    onSubmit: (newSession: Session) => void;
}


function getModalStyle() {
    return {
        top: `50%`,
        left: `50%`,
        transform: `translate(-50%, -50%)`,
    };
}

const useStyles = makeStyles((theme) => ({
    paper: {
        position: 'absolute',
        backgroundColor: theme.palette.background.paper,
        border: '2px solid #000',
        boxShadow: theme.shadows[5],
        padding: theme.spacing(2, 4, 3),
    },
}));

export default function EditForm({ session, onSubmit, ...other }: any) {
    const classes = useStyles();
    // getModalStyle is not a pure function, we roll the style only on the first render
    const [modalStyle] = React.useState(getModalStyle);
    const [open, setOpen] = React.useState(false);
    const [fields, setFields] = React.useState(session)

    const clickSubmit = () => {
        onSubmit(fields);
        setOpen(false);
    }

    const body = (
        <div style={modalStyle} className={classes.paper}>
            <Grid
                container
                direction="column"
                justify="space-evenly"
                alignItems="center"
                spacing={2}
            >
                <Grid item>
                    <Typography variant="h5" align="center">{session.title}</Typography>
                </Grid>
                <Grid item id="edit">
                    <Typography variant="subtitle2">Edit</Typography>
                </Grid>
                <Grid item>
                    <TextField label="Title" defaultValue={fields.title} onChange={e => setFields({ ...fields, title: e.target.value })} />
                </Grid>
                <Grid item>
                    <TextField label="Speaker" defaultValue={fields.speaker} onChange={e => setFields({ ...fields, speaker: e.target.value })} />
                </Grid>
                <Grid item>
                    <TextField label="Time" defaultValue={fields.time} onChange={e => setFields({ ...fields, time: e.target.value })} />
                </Grid>
                <Grid item>
                    <TextField label="Room" defaultValue={fields.room} onChange={e => setFields({ ...fields, room: e.target.value })} />
                </Grid>
                <Grid item>
                    <TextField label="Description" defaultValue={fields.description} onChange={e => setFields({ ...fields, description: e.target.value })} />
                </Grid>
                <Grid item>
                    <TextField label="Votes" defaultValue={fields.votes} onChange={e => setFields({ ...fields, votes: parseInt(e.target.value) })} />
                </Grid>
                {/* Object.keys(fields).map(field => <TextField label={field} defaultValue={fields[field]} onChange={e => setFields(field, e.target.value)} />) */}
                <Grid item>
                    <ButtonGroup>
                        <Button onClick={clickSubmit} id="btn-submit" size="large">Submit</Button>
                    </ButtonGroup>
                </Grid>
            </Grid>
        </div>
    );

    return (
        <>
            <Button {...other} onClick={() => setOpen(true)}>
                <EditIcon />
            </Button>
            <Modal
                open={open}
                onClose={() => setOpen(false)}
                aria-labelledby="simple-modal-title"
                aria-describedby="simple-modal-description"
                closeAfterTransition
                BackdropComponent={Backdrop}
                BackdropProps={{
                    timeout: 500,
                }}

            >
                <Fade in={open}>
                    {body}
                </Fade>
            </Modal>
        </>
    );
}