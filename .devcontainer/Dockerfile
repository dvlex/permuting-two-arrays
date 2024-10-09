FROM lexdrel/dotnet8:ubuntu24

# Update package list and upgrade existing packages
RUN apt-get update && apt-get upgrade -y

# Receive the developer user's UID and USER:
ARG DEVELOPER_UID=1000
ARG DEVELOPER_USERNAME=you

# Remove the existing user 'ubuntu'
RUN userdel -r ubuntu

# Receive the developer user's UID and USER:
ARG DEVELOPER_UID=1000
ARG DEVELOPER_USERNAME=you
    
# Replicate the developer user in the development image:
RUN groupadd --gid ${DEVELOPER_UID} ${DEVELOPER_USERNAME} \
    && useradd -r -m -u ${DEVELOPER_UID} --gid ${DEVELOPER_UID} \
    --shell /bin/bash -c "Developer User,,," ${DEVELOPER_USERNAME} \
    && echo "${DEVELOPER_USERNAME}:1234" | chpasswd \
    && usermod -aG sudo ${DEVELOPER_USERNAME}

# Ensure that the home directory, the app path and bundler directories are owned
# by the developer user:z
# (A workaround to a side effect of setting WORKDIR before creating the user)
RUN userhome=$(eval echo ~${DEVELOPER_USERNAME}) \
    && chown -R ${DEVELOPER_USERNAME}:${DEVELOPER_USERNAME} $userhome \
    && mkdir -p /workspaces/${localWorkspaceFolderBasename} \
    && chown -R ${DEVELOPER_USERNAME}:${DEVELOPER_USERNAME} /workspaces/${localWorkspaceFolderBasename} \
    && mkdir -p /home/${DEVELOPER_USERNAME} \
    && chown -R ${DEVELOPER_USERNAME}:${DEVELOPER_USERNAME} /home/${DEVELOPER_USERNAME}
    
# Switch to the developer user
USER ${DEVELOPER_USERNAME}
    
# Install Oh My Zsh
RUN sh -c "$(curl -fsSL https://raw.githubusercontent.com/ohmyzsh/ohmyzsh/master/tools/install.sh)" "" --unattended

# # Set the theme to robbyrussell
# RUN echo 's/ZSH_THEME=".*"/ZSH_THEME="mikeh"/' >> ~/.zshrc

# RUN sudo chsh -s $(which zsh)