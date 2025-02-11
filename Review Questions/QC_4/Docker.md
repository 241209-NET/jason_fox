# Docker
## Docker Concepts/Terms
- What is containerization? 
	- Software development and deployment process that packages an app and its dependencies into a container
	- Containers are self-contained units that can run on any OS
- What problem are we solving with containerization and/or virtualization?
	- Ensuring consistent application environments across different dev, test, and prod environments
- How is containerization different from virtualization?
	- Containers share the host OS, VMs run as standalone systems
	- Differ in how they use resources, levels of control, and flexibility
- What is docker?
	- Open-source platform that allows developers to build, test, and deploy apps using containers
- What is docker engine?
	- Core component of docker
	- Client-server application that allows users to build, manage, and run containerized applications
	- daemon process called "dockerd" accessed through Docker CLI
- what is dockerfile?
	- Text file that contains instructions for building a Docker image
	- Specifies base image to use, commands to run, and other configurations
- what is .dockerignore file?
	- Similar to .gitignore, ignores files when copying
- what is image?
	- Template that contains instructions for creating a docker container
- what is container?
	- Standalone package that encapsulates an application with all its dependencies
- what is a tag?
	- Custom label that identifies a specific version or variant of a docker image
- what is image registry?
	- Storage and distribution system for Docker images
	- Stores and organizes images into public or private repositories
- What is base image?
	- Starting point for building container images
	- Usually an empty layer that contains OS and sometimes app frameworks
	- Extended by created image
## Docker Commands
- What command do you use to build an image
	- docker build
- How do you run an image in a container?
	- docker run command with the image name
- In dockerfile...
	- What does FROM do?
		- Specifies base image
	- WORKDIR ?
		- Sets working directory
	- RUN?
		- Executes commands that build and configure the docker image
	- CMD?
		- Specifies the default command to be executed when a container is started from the image
	- ENTRYPOINT?
	 	- Same as CMD but parameters cannot be overridden
- how do you push/pull image from image registry?
	- docker push/pull